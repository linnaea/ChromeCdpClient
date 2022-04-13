using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CdpClient;

public class JsonRpcResponse<TData, TError>
{
    [JsonPropertyName("id")]
    public uint Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonPropertyName("result")]
    public TData Result { get; init; } = default!;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonPropertyName("error")]
    public TError Error { get; init; } = default!;
}

public class JsonRpcRequest<TData>
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull), JsonPropertyName("id")]
    public uint? Id { get; init; }

    [JsonPropertyName("method")] public string? Method { get; init; }

    [JsonPropertyName("params")] public TData Params { get; init; } = default!;
}

public class JsonRpcMeta
{
    [JsonPropertyName("id")] public uint? Id { get; init; }
    [JsonPropertyName("method")] public string? Method { get; init; }
}

public class VoidData
{
    public static readonly VoidData Instance = new();
}

public class StringEnumConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsEnum && typeToConvert.GetCustomAttribute<FlagsAttribute>() == null;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return (JsonConverter)typeof(Converter<>).MakeGenericType(typeToConvert)
                                                 .GetField(nameof(Converter<object>.Instance))
                                                 .GetValue(null);
    }

    public class Converter<T> : JsonConverter<T>
    {
        public static readonly Converter<T> Instance = new();

        private readonly IReadOnlyDictionary<T, string> _forward;
        private readonly IReadOnlyDictionary<string, T> _backward;

        private Converter()
        {
            var fwd = new Dictionary<T, string>();
            var back = new Dictionary<string, T>();
            foreach (var member in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)) {
                var name = member.GetCustomAttribute<EnumMemberAttribute>()?.Value;
                if(name == null) continue;
                var value = (T)member.GetValue(null);
                fwd.Add(value, name);
                back.Add(name, value);
            }

            _forward = fwd;
            _backward = back;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return _backward[reader.GetString()!];
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_forward[value]);
        }
    }
}

public class AliasedTypeValueConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsValueType) return false;
        var fields = typeToConvert.GetProperties();
        if (fields.Length != 1) return false;
        if (fields.Single().Name != "Value") return false;
        return true;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return (JsonConverter)typeof(Converter<,>).MakeGenericType(typeToConvert, typeToConvert.GetProperties().Single().PropertyType)
                                                  .GetField(nameof(Converter<int, object>.Instance))
                                                  .GetValue(null);
    }

    public class Converter<TType, TBacking> : JsonConverter<TType> where TType : struct
    {
        public static readonly Converter<TType, TBacking> Instance = new();

        private Converter()
        {
        }

        public override TType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            object v = new TType();
            var b = JsonSerializer.Deserialize<TBacking>(ref reader, options);
            typeof(TType).GetProperties().Single().SetValue(v, b);
            return (TType)v;
        }

        public override void Write(Utf8JsonWriter writer, TType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, typeof(TType).GetProperties().Single().GetValue(value), options);
        }
    }
}
