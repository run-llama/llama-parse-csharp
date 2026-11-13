using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Models.Extract.Review;

public class ExtractReviewEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedActorID = "actor_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Kind> expectedKind = Kind.Approved;
        Detail expectedDetail = new ExtractReviewCreatedDetail()
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };
        string expectedPath = "path";
        JsonElement expectedValueAfter = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedValueBefore = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActorID, model.ActorID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedDetail, model.Detail);
        Assert.Equal(expectedPath, model.Path);
        Assert.NotNull(model.ValueAfter);
        Assert.True(JsonElement.DeepEquals(expectedValueAfter, model.ValueAfter.Value));
        Assert.NotNull(model.ValueBefore);
        Assert.True(JsonElement.DeepEquals(expectedValueBefore, model.ValueBefore.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedActorID = "actor_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Kind> expectedKind = Kind.Approved;
        Detail expectedDetail = new ExtractReviewCreatedDetail()
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };
        string expectedPath = "path";
        JsonElement expectedValueAfter = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedValueBefore = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActorID, deserialized.ActorID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedDetail, deserialized.Detail);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.NotNull(deserialized.ValueAfter);
        Assert.True(JsonElement.DeepEquals(expectedValueAfter, deserialized.ValueAfter.Value));
        Assert.NotNull(deserialized.ValueBefore);
        Assert.True(JsonElement.DeepEquals(expectedValueBefore, deserialized.ValueBefore.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
        };

        Assert.Null(model.ValueAfter);
        Assert.False(model.RawData.ContainsKey("value_after"));
        Assert.Null(model.ValueBefore);
        Assert.False(model.RawData.ContainsKey("value_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ValueAfter = null,
            ValueBefore = null,
        };

        Assert.Null(model.ValueAfter);
        Assert.False(model.RawData.ContainsKey("value_after"));
        Assert.Null(model.ValueBefore);
        Assert.False(model.RawData.ContainsKey("value_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ValueAfter = null,
            ValueBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Detail);
        Assert.False(model.RawData.ContainsKey("detail"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),

            Detail = null,
            Path = null,
        };

        Assert.Null(model.Detail);
        Assert.True(model.RawData.ContainsKey("detail"));
        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),

            Detail = null,
            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractReviewEvent
        {
            ID = "id",
            ActorID = "actor_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = Kind.Approved,
            Detail = new ExtractReviewCreatedDetail()
            {
                ConfidenceThreshold = 0,
                FieldsInScope = ["string"],
                Origin = Origin.Api,
                RequiredFields = ["string"],
            },
            Path = "path",
            ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
            ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ExtractReviewEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class KindTest : TestBase
{
    [Theory]
    [InlineData(Kind.Approved)]
    [InlineData(Kind.Created)]
    [InlineData(Kind.FieldCleared)]
    [InlineData(Kind.FieldConfirmed)]
    [InlineData(Kind.FieldCorrected)]
    [InlineData(Kind.FieldRestored)]
    [InlineData(Kind.FieldUndone)]
    [InlineData(Kind.FlagsSignedOff)]
    [InlineData(Kind.Rejected)]
    [InlineData(Kind.Reopened)]
    public void Validation_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Kind.Approved)]
    [InlineData(Kind.Created)]
    [InlineData(Kind.FieldCleared)]
    [InlineData(Kind.FieldConfirmed)]
    [InlineData(Kind.FieldCorrected)]
    [InlineData(Kind.FieldRestored)]
    [InlineData(Kind.FieldUndone)]
    [InlineData(Kind.FlagsSignedOff)]
    [InlineData(Kind.Rejected)]
    [InlineData(Kind.Reopened)]
    public void SerializationRoundtrip_Works(Kind rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Kind> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Kind>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DetailTest : TestBase
{
    [Fact]
    public void ExtractReviewCreatedValidationWorks()
    {
        Detail value = new ExtractReviewCreatedDetail()
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };
        value.Validate();
    }

    [Fact]
    public void ExtractReviewRejectedValidationWorks()
    {
        Detail value = new ExtractReviewRejectedDetail("reason");
        value.Validate();
    }

    [Fact]
    public void ExtractReviewSignedOffValidationWorks()
    {
        Detail value = new ExtractReviewSignedOffDetail(["string"]);
        value.Validate();
    }

    [Fact]
    public void ExtractReviewCreatedSerializationRoundtripWorks()
    {
        Detail value = new ExtractReviewCreatedDetail()
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Detail>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractReviewRejectedSerializationRoundtripWorks()
    {
        Detail value = new ExtractReviewRejectedDetail("reason");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Detail>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractReviewSignedOffSerializationRoundtripWorks()
    {
        Detail value = new ExtractReviewSignedOffDetail(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Detail>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExtractReviewCreatedDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractReviewCreatedDetail
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };

        double expectedConfidenceThreshold = 0;
        List<string> expectedFieldsInScope = ["string"];
        ApiEnum<string, Origin> expectedOrigin = Origin.Api;
        List<string> expectedRequiredFields = ["string"];

        Assert.Equal(expectedConfidenceThreshold, model.ConfidenceThreshold);
        Assert.Equal(expectedFieldsInScope.Count, model.FieldsInScope.Count);
        for (int i = 0; i < expectedFieldsInScope.Count; i++)
        {
            Assert.Equal(expectedFieldsInScope[i], model.FieldsInScope[i]);
        }
        Assert.Equal(expectedOrigin, model.Origin);
        Assert.Equal(expectedRequiredFields.Count, model.RequiredFields.Count);
        for (int i = 0; i < expectedRequiredFields.Count; i++)
        {
            Assert.Equal(expectedRequiredFields[i], model.RequiredFields[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractReviewCreatedDetail
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewCreatedDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractReviewCreatedDetail
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewCreatedDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedConfidenceThreshold = 0;
        List<string> expectedFieldsInScope = ["string"];
        ApiEnum<string, Origin> expectedOrigin = Origin.Api;
        List<string> expectedRequiredFields = ["string"];

        Assert.Equal(expectedConfidenceThreshold, deserialized.ConfidenceThreshold);
        Assert.Equal(expectedFieldsInScope.Count, deserialized.FieldsInScope.Count);
        for (int i = 0; i < expectedFieldsInScope.Count; i++)
        {
            Assert.Equal(expectedFieldsInScope[i], deserialized.FieldsInScope[i]);
        }
        Assert.Equal(expectedOrigin, deserialized.Origin);
        Assert.Equal(expectedRequiredFields.Count, deserialized.RequiredFields.Count);
        for (int i = 0; i < expectedRequiredFields.Count; i++)
        {
            Assert.Equal(expectedRequiredFields[i], deserialized.RequiredFields[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractReviewCreatedDetail
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractReviewCreatedDetail
        {
            ConfidenceThreshold = 0,
            FieldsInScope = ["string"],
            Origin = Origin.Api,
            RequiredFields = ["string"],
        };

        ExtractReviewCreatedDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginTest : TestBase
{
    [Theory]
    [InlineData(Origin.Api)]
    [InlineData(Origin.Edit)]
    [InlineData(Origin.History)]
    [InlineData(Origin.Policy)]
    [InlineData(Origin.Run)]
    public void Validation_Works(Origin rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Origin> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Origin>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Origin.Api)]
    [InlineData(Origin.Edit)]
    [InlineData(Origin.History)]
    [InlineData(Origin.Policy)]
    [InlineData(Origin.Run)]
    public void SerializationRoundtrip_Works(Origin rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Origin> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Origin>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Origin>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Origin>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractReviewRejectedDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractReviewRejectedDetail { Reason = "reason" };

        string expectedReason = "reason";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractReviewRejectedDetail { Reason = "reason" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewRejectedDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractReviewRejectedDetail { Reason = "reason" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewRejectedDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "reason";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractReviewRejectedDetail { Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractReviewRejectedDetail { Reason = "reason" };

        ExtractReviewRejectedDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractReviewSignedOffDetailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractReviewSignedOffDetail { Paths = ["string"] };

        List<string> expectedPaths = ["string"];

        Assert.Equal(expectedPaths.Count, model.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], model.Paths[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractReviewSignedOffDetail { Paths = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewSignedOffDetail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractReviewSignedOffDetail { Paths = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractReviewSignedOffDetail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedPaths = ["string"];

        Assert.Equal(expectedPaths.Count, deserialized.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], deserialized.Paths[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractReviewSignedOffDetail { Paths = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractReviewSignedOffDetail { Paths = ["string"] };

        ExtractReviewSignedOffDetail copied = new(model);

        Assert.Equal(model, copied);
    }
}
