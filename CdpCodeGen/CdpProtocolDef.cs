using System;
using System.Text.Json.Serialization;

namespace CdpCodeGen;

public class CdpProtocolDef
{
    public class VersionDef
    {
        [JsonPropertyName("major")] public string Major { get; set; }
        [JsonPropertyName("minor")] public string Minor { get; set; }
    }
    
    [JsonPropertyName("version")] public VersionDef Version { get; set; }
    [JsonPropertyName("domains")] public CdpDomainDef[] Domains { get; set; }
}

public class CdpDomainDef
{
    [JsonPropertyName("domain")] public string Domain { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("dependencies")] public string[] Dependencies { get; set; } = Array.Empty<string>();
    [JsonPropertyName("deprecated")] public bool Deprecated { get; set; }
    [JsonPropertyName("experimental")] public bool Experimental { get; set; }

    [JsonPropertyName("types")] public CdpTypeDef[] Types { get; set; } = Array.Empty<CdpTypeDef>();
    [JsonPropertyName("commands")] public CdpCommandDef[] Commands { get; set; } = Array.Empty<CdpCommandDef>();
    [JsonPropertyName("events")] public CdpCommandDef[] Events { get; set; } = Array.Empty<CdpCommandDef>();
}

public class CdpTypeDef
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("enum")] public string[] Enum { get; set; }
    [JsonPropertyName("properties")] public CdpPropertyDef[] Properties { get; set; } = Array.Empty<CdpPropertyDef>();
    [JsonPropertyName("items")] public CdpArrayItemDef Items { get; set; }
    [JsonPropertyName("deprecated")] public bool Deprecated { get; set; }
    [JsonPropertyName("experimental")] public bool Experimental { get; set; }
}

public class CdpPropertyDef
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; } = "";
    [JsonPropertyName("optional")] public bool Optional { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("$ref")] public string TypeRef { get; set; }
    [JsonPropertyName("items")] public CdpArrayItemDef Items { get; set; }
    [JsonPropertyName("deprecated")] public bool Deprecated { get; set; }
    [JsonPropertyName("experimental")] public bool Experimental { get; set; }
    [JsonPropertyName("enum")] public string[] Enum { get; set; }
}

public class CdpArrayItemDef
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("$ref")] public string TypeRef { get; set; }
}

public class CdpCommandDef
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("redirect")] public string Redirect { get; set; }
    [JsonPropertyName("parameters")] public CdpPropertyDef[] Parameters { get; set; } = Array.Empty<CdpPropertyDef>();
    [JsonPropertyName("returns")] public CdpPropertyDef[] Returns { get; set; } = Array.Empty<CdpPropertyDef>();
    [JsonPropertyName("deprecated")] public bool Deprecated { get; set; }
    [JsonPropertyName("experimental")] public bool Experimental { get; set; }
}
