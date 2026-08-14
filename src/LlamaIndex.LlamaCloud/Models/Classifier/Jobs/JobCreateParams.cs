using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// Create a classify job. Experimental: not production-ready and subject to change.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("Please use `client.classify.create()`")]
public record class JobCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The IDs of the files to classify
    /// </summary>
    public required IReadOnlyList<string> FileIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("file_ids");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "file_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The rules to classify the files
    /// </summary>
    public required IReadOnlyList<ClassifierRule> Rules
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ClassifierRule>>("rules");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<ClassifierRule>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    /// <summary>
    /// The classification mode to use
    /// </summary>
    public ApiEnum<string, Mode>? Mode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Mode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("mode", value);
        }
    }

    /// <summary>
    /// The configuration for the parsing job
    /// </summary>
    public ClassifyParsingConfiguration? ParsingConfiguration
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ClassifyParsingConfiguration>(
                "parsing_configuration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("parsing_configuration", value);
        }
    }

    /// <summary>
    /// List of webhook configurations for notifications
    /// </summary>
    public IReadOnlyList<WebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<WebhookConfiguration>>(
                "webhook_configurations"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<WebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JobCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobCreateParams(JobCreateParams jobCreateParams)
        : base(jobCreateParams)
    {
        this._rawBodyData = new(jobCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public JobCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static JobCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(JobCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/classifier/jobs")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The classification mode to use
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Fast,
    Multimodal,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FAST" => Mode.Fast,
            "MULTIMODAL" => Mode.Multimodal,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Fast => "FAST",
                Mode.Multimodal => "MULTIMODAL",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Webhook configuration for receiving parsing job notifications.
///
/// <para>Webhooks are called when specified events occur during job processing.
/// Configure multiple webhook configurations to send to different endpoints.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfiguration, WebhookConfigurationFromRaw>))]
public sealed record class WebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events that trigger this webhook. Options: 'parse.success' (job completed),
    /// 'parse.error' (job failed), 'parse.partial_success' (some pages failed),
    /// 'parse.pending', 'parse.running', 'parse.cancelled'. If not specified, webhook
    /// fires for all events
    /// </summary>
    public IReadOnlyList<string>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("webhook_events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers to include in webhook requests. Use for authentication
    /// tokens or custom routing. Example: {'Authorization': 'Bearer xyz'}
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? WebhookHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "webhook_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "webhook_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Format of the webhook payload body. 'string' (default) sends the payload as
    /// a JSON-encoded string; 'json' sends it as a JSON object.
    /// </summary>
    public ApiEnum<string, WebhookOutputFormat>? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookOutputFormat>>(
                "webhook_output_format"
            );
        }
        init { this._rawData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Shared signing secret used to sign webhook deliveries. When set, each request
    /// includes an HMAC-SHA256 signature of the request body in the 'LC-Signature'
    /// header (value 'sha256=&lt;hex&gt;'). Recompute the HMAC over the raw request
    /// body with this secret to verify the delivery is authentic.
    /// </summary>
    public string? WebhookSigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_signing_secret");
        }
        init { this._rawData.Set("webhook_signing_secret", value); }
    }

    /// <summary>
    /// HTTPS URL to receive webhook POST requests. Must be publicly accessible
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_url");
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.WebhookEvents;
        _ = this.WebhookHeaders;
        this.WebhookOutputFormat?.Validate();
        _ = this.WebhookSigningSecret;
        _ = this.WebhookUrl;
    }

    public WebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfiguration(WebhookConfiguration webhookConfiguration)
        : base(webhookConfiguration) { }
#pragma warning restore CS8618

    public WebhookConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookConfigurationFromRaw : IFromRawJson<WebhookConfiguration>
{
    /// <inheritdoc/>
    public WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookConfiguration.FromRawUnchecked(rawData);
}

/// <summary>
/// Format of the webhook payload body. 'string' (default) sends the payload as a
/// JSON-encoded string; 'json' sends it as a JSON object.
/// </summary>
[JsonConverter(typeof(WebhookOutputFormatConverter))]
public enum WebhookOutputFormat
{
    Json,
    String,
}

sealed class WebhookOutputFormatConverter : JsonConverter<WebhookOutputFormat>
{
    public override WebhookOutputFormat Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "json" => WebhookOutputFormat.Json,
            "string" => WebhookOutputFormat.String,
            _ => (WebhookOutputFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookOutputFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookOutputFormat.Json => "json",
                WebhookOutputFormat.String => "string",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
