using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudSlackDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };

        string expectedSlackToken = "slack_token";
        string expectedChannelIds = "channel_ids";
        string expectedChannelPatterns = "channel_patterns";
        string expectedClassName = "class_name";
        string expectedEarliestDate = "earliest_date";
        double expectedEarliestDateTimestamp = 0;
        string expectedLatestDate = "latest_date";
        double expectedLatestDateTimestamp = 0;
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedSlackToken, model.SlackToken);
        Assert.Equal(expectedChannelIds, model.ChannelIds);
        Assert.Equal(expectedChannelPatterns, model.ChannelPatterns);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEarliestDate, model.EarliestDate);
        Assert.Equal(expectedEarliestDateTimestamp, model.EarliestDateTimestamp);
        Assert.Equal(expectedLatestDate, model.LatestDate);
        Assert.Equal(expectedLatestDateTimestamp, model.LatestDateTimestamp);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudSlackDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudSlackDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSlackToken = "slack_token";
        string expectedChannelIds = "channel_ids";
        string expectedChannelPatterns = "channel_patterns";
        string expectedClassName = "class_name";
        string expectedEarliestDate = "earliest_date";
        double expectedEarliestDateTimestamp = 0;
        string expectedLatestDate = "latest_date";
        double expectedLatestDateTimestamp = 0;
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedSlackToken, deserialized.SlackToken);
        Assert.Equal(expectedChannelIds, deserialized.ChannelIds);
        Assert.Equal(expectedChannelPatterns, deserialized.ChannelPatterns);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEarliestDate, deserialized.EarliestDate);
        Assert.Equal(expectedEarliestDateTimestamp, deserialized.EarliestDateTimestamp);
        Assert.Equal(expectedLatestDate, deserialized.LatestDate);
        Assert.Equal(expectedLatestDateTimestamp, deserialized.LatestDateTimestamp);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,

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
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.ChannelIds);
        Assert.False(model.RawData.ContainsKey("channel_ids"));
        Assert.Null(model.ChannelPatterns);
        Assert.False(model.RawData.ContainsKey("channel_patterns"));
        Assert.Null(model.EarliestDate);
        Assert.False(model.RawData.ContainsKey("earliest_date"));
        Assert.Null(model.EarliestDateTimestamp);
        Assert.False(model.RawData.ContainsKey("earliest_date_timestamp"));
        Assert.Null(model.LatestDate);
        Assert.False(model.RawData.ContainsKey("latest_date"));
        Assert.Null(model.LatestDateTimestamp);
        Assert.False(model.RawData.ContainsKey("latest_date_timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ClassName = "class_name",
            SupportsAccessControl = true,

            ChannelIds = null,
            ChannelPatterns = null,
            EarliestDate = null,
            EarliestDateTimestamp = null,
            LatestDate = null,
            LatestDateTimestamp = null,
        };

        Assert.Null(model.ChannelIds);
        Assert.True(model.RawData.ContainsKey("channel_ids"));
        Assert.Null(model.ChannelPatterns);
        Assert.True(model.RawData.ContainsKey("channel_patterns"));
        Assert.Null(model.EarliestDate);
        Assert.True(model.RawData.ContainsKey("earliest_date"));
        Assert.Null(model.EarliestDateTimestamp);
        Assert.True(model.RawData.ContainsKey("earliest_date_timestamp"));
        Assert.Null(model.LatestDate);
        Assert.True(model.RawData.ContainsKey("latest_date"));
        Assert.Null(model.LatestDateTimestamp);
        Assert.True(model.RawData.ContainsKey("latest_date_timestamp"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ClassName = "class_name",
            SupportsAccessControl = true,

            ChannelIds = null,
            ChannelPatterns = null,
            EarliestDate = null,
            EarliestDateTimestamp = null,
            LatestDate = null,
            LatestDateTimestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudSlackDataSource
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };

        CloudSlackDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
