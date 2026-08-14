using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudS3DataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };

        string expectedBucket = "bucket";
        string expectedAwsAccessID = "aws_access_id";
        string expectedAwsAccessSecret = "aws_access_secret";
        string expectedClassName = "class_name";
        string expectedPrefix = "prefix";
        string expectedRegexPattern = "regex_pattern";
        string expectedS3EndpointUrl = "s3_endpoint_url";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedAwsAccessID, model.AwsAccessID);
        Assert.Equal(expectedAwsAccessSecret, model.AwsAccessSecret);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedRegexPattern, model.RegexPattern);
        Assert.Equal(expectedS3EndpointUrl, model.S3EndpointUrl);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudS3DataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudS3DataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucket = "bucket";
        string expectedAwsAccessID = "aws_access_id";
        string expectedAwsAccessSecret = "aws_access_secret";
        string expectedClassName = "class_name";
        string expectedPrefix = "prefix";
        string expectedRegexPattern = "regex_pattern";
        string expectedS3EndpointUrl = "s3_endpoint_url";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedAwsAccessID, deserialized.AwsAccessID);
        Assert.Equal(expectedAwsAccessSecret, deserialized.AwsAccessSecret);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedRegexPattern, deserialized.RegexPattern);
        Assert.Equal(expectedS3EndpointUrl, deserialized.S3EndpointUrl);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.AwsAccessID);
        Assert.False(model.RawData.ContainsKey("aws_access_id"));
        Assert.Null(model.AwsAccessSecret);
        Assert.False(model.RawData.ContainsKey("aws_access_secret"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.RegexPattern);
        Assert.False(model.RawData.ContainsKey("regex_pattern"));
        Assert.Null(model.S3EndpointUrl);
        Assert.False(model.RawData.ContainsKey("s3_endpoint_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            ClassName = "class_name",
            SupportsAccessControl = true,

            AwsAccessID = null,
            AwsAccessSecret = null,
            Prefix = null,
            RegexPattern = null,
            S3EndpointUrl = null,
        };

        Assert.Null(model.AwsAccessID);
        Assert.True(model.RawData.ContainsKey("aws_access_id"));
        Assert.Null(model.AwsAccessSecret);
        Assert.True(model.RawData.ContainsKey("aws_access_secret"));
        Assert.Null(model.Prefix);
        Assert.True(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.RegexPattern);
        Assert.True(model.RawData.ContainsKey("regex_pattern"));
        Assert.Null(model.S3EndpointUrl);
        Assert.True(model.RawData.ContainsKey("s3_endpoint_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            ClassName = "class_name",
            SupportsAccessControl = true,

            AwsAccessID = null,
            AwsAccessSecret = null,
            Prefix = null,
            RegexPattern = null,
            S3EndpointUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudS3DataSource
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };

        CloudS3DataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
