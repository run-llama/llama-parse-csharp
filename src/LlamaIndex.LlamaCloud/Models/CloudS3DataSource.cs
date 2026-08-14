using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

[JsonConverter(typeof(JsonModelConverter<CloudS3DataSource, CloudS3DataSourceFromRaw>))]
public sealed record class CloudS3DataSource : JsonModel
{
    /// <summary>
    /// The name of the S3 bucket to read from.
    /// </summary>
    public required string Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket");
        }
        init { this._rawData.Set("bucket", value); }
    }

    /// <summary>
    /// The AWS access ID to use for authentication.
    /// </summary>
    public string? AwsAccessID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aws_access_id");
        }
        init { this._rawData.Set("aws_access_id", value); }
    }

    /// <summary>
    /// The AWS access secret to use for authentication.
    /// </summary>
    public string? AwsAccessSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aws_access_secret");
        }
        init { this._rawData.Set("aws_access_secret", value); }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// The prefix of the S3 objects to read from.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
    }

    /// <summary>
    /// The regex pattern to filter S3 objects. Must be a valid regex pattern.
    /// </summary>
    public string? RegexPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regex_pattern");
        }
        init { this._rawData.Set("regex_pattern", value); }
    }

    /// <summary>
    /// The S3 endpoint URL to use for authentication.
    /// </summary>
    public string? S3EndpointUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("s3_endpoint_url");
        }
        init { this._rawData.Set("s3_endpoint_url", value); }
    }

    public bool? SupportsAccessControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supports_access_control");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supports_access_control", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bucket;
        _ = this.AwsAccessID;
        _ = this.AwsAccessSecret;
        _ = this.ClassName;
        _ = this.Prefix;
        _ = this.RegexPattern;
        _ = this.S3EndpointUrl;
        _ = this.SupportsAccessControl;
    }

    public CloudS3DataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudS3DataSource(CloudS3DataSource cloudS3DataSource)
        : base(cloudS3DataSource) { }
#pragma warning restore CS8618

    public CloudS3DataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudS3DataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudS3DataSourceFromRaw.FromRawUnchecked"/>
    public static CloudS3DataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudS3DataSource(string bucket)
        : this()
    {
        this.Bucket = bucket;
    }
}

class CloudS3DataSourceFromRaw : IFromRawJson<CloudS3DataSource>
{
    /// <inheritdoc/>
    public CloudS3DataSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudS3DataSource.FromRawUnchecked(rawData);
}
