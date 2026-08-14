using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Configurations;

/// <summary>
/// Catch-all for configurations without a dedicated typed schema.
///
/// <para>Accepts arbitrary JSON fields alongside ``product_type``.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UntypedParameters, UntypedParametersFromRaw>))]
public sealed record class UntypedParameters : JsonModel
{
    /// <summary>
    /// Product type.
    /// </summary>
    public JsonElement ProductType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("product_type");
        }
        init { this._rawData.Set("product_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.ProductType, JsonSerializer.SerializeToElement("unknown")))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
    }

    public UntypedParameters()
    {
        this.ProductType = JsonSerializer.SerializeToElement("unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UntypedParameters(UntypedParameters untypedParameters)
        : base(untypedParameters) { }
#pragma warning restore CS8618

    public UntypedParameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ProductType = JsonSerializer.SerializeToElement("unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UntypedParameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UntypedParametersFromRaw.FromRawUnchecked"/>
    public static UntypedParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UntypedParametersFromRaw : IFromRawJson<UntypedParameters>
{
    /// <inheritdoc/>
    public UntypedParameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UntypedParameters.FromRawUnchecked(rawData);
}
