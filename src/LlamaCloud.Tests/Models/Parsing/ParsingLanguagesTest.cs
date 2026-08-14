using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingLanguagesTest : TestBase
{
    [Theory]
    [InlineData(ParsingLanguages.Abq)]
    [InlineData(ParsingLanguages.Ady)]
    [InlineData(ParsingLanguages.Af)]
    [InlineData(ParsingLanguages.Ang)]
    [InlineData(ParsingLanguages.Ar)]
    [InlineData(ParsingLanguages.As)]
    [InlineData(ParsingLanguages.Ava)]
    [InlineData(ParsingLanguages.Az)]
    [InlineData(ParsingLanguages.Be)]
    [InlineData(ParsingLanguages.Bg)]
    [InlineData(ParsingLanguages.Bgc)]
    [InlineData(ParsingLanguages.Bh)]
    [InlineData(ParsingLanguages.Bho)]
    [InlineData(ParsingLanguages.Bn)]
    [InlineData(ParsingLanguages.Bs)]
    [InlineData(ParsingLanguages.ChSim)]
    [InlineData(ParsingLanguages.ChTra)]
    [InlineData(ParsingLanguages.Che)]
    [InlineData(ParsingLanguages.Cs)]
    [InlineData(ParsingLanguages.Cy)]
    [InlineData(ParsingLanguages.Da)]
    [InlineData(ParsingLanguages.Dar)]
    [InlineData(ParsingLanguages.De)]
    [InlineData(ParsingLanguages.En)]
    [InlineData(ParsingLanguages.Es)]
    [InlineData(ParsingLanguages.Et)]
    [InlineData(ParsingLanguages.Fa)]
    [InlineData(ParsingLanguages.Fr)]
    [InlineData(ParsingLanguages.Ga)]
    [InlineData(ParsingLanguages.Gom)]
    [InlineData(ParsingLanguages.Hi)]
    [InlineData(ParsingLanguages.Hr)]
    [InlineData(ParsingLanguages.Hu)]
    [InlineData(ParsingLanguages.ID)]
    [InlineData(ParsingLanguages.Inh)]
    [InlineData(ParsingLanguages.Is)]
    [InlineData(ParsingLanguages.It)]
    [InlineData(ParsingLanguages.Ja)]
    [InlineData(ParsingLanguages.Kbd)]
    [InlineData(ParsingLanguages.Kn)]
    [InlineData(ParsingLanguages.Ko)]
    [InlineData(ParsingLanguages.Ku)]
    [InlineData(ParsingLanguages.La)]
    [InlineData(ParsingLanguages.Lbe)]
    [InlineData(ParsingLanguages.Lez)]
    [InlineData(ParsingLanguages.Lt)]
    [InlineData(ParsingLanguages.Lv)]
    [InlineData(ParsingLanguages.Mah)]
    [InlineData(ParsingLanguages.Mai)]
    [InlineData(ParsingLanguages.Mi)]
    [InlineData(ParsingLanguages.Mn)]
    [InlineData(ParsingLanguages.Mni)]
    [InlineData(ParsingLanguages.Mr)]
    [InlineData(ParsingLanguages.Ms)]
    [InlineData(ParsingLanguages.Mt)]
    [InlineData(ParsingLanguages.Ne)]
    [InlineData(ParsingLanguages.New)]
    [InlineData(ParsingLanguages.Nl)]
    [InlineData(ParsingLanguages.No)]
    [InlineData(ParsingLanguages.Oc)]
    [InlineData(ParsingLanguages.Pi)]
    [InlineData(ParsingLanguages.Pl)]
    [InlineData(ParsingLanguages.Pt)]
    [InlineData(ParsingLanguages.Ro)]
    [InlineData(ParsingLanguages.RsCyrillic)]
    [InlineData(ParsingLanguages.RsLatin)]
    [InlineData(ParsingLanguages.Ru)]
    [InlineData(ParsingLanguages.Sa)]
    [InlineData(ParsingLanguages.Sck)]
    [InlineData(ParsingLanguages.Sk)]
    [InlineData(ParsingLanguages.Sl)]
    [InlineData(ParsingLanguages.Sq)]
    [InlineData(ParsingLanguages.Sv)]
    [InlineData(ParsingLanguages.Sw)]
    [InlineData(ParsingLanguages.Ta)]
    [InlineData(ParsingLanguages.Tab)]
    [InlineData(ParsingLanguages.Te)]
    [InlineData(ParsingLanguages.Th)]
    [InlineData(ParsingLanguages.Tjk)]
    [InlineData(ParsingLanguages.Tl)]
    [InlineData(ParsingLanguages.Tr)]
    [InlineData(ParsingLanguages.Ug)]
    [InlineData(ParsingLanguages.Uk)]
    [InlineData(ParsingLanguages.Ur)]
    [InlineData(ParsingLanguages.Uz)]
    [InlineData(ParsingLanguages.Vi)]
    public void Validation_Works(ParsingLanguages rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingLanguages> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingLanguages>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParsingLanguages.Abq)]
    [InlineData(ParsingLanguages.Ady)]
    [InlineData(ParsingLanguages.Af)]
    [InlineData(ParsingLanguages.Ang)]
    [InlineData(ParsingLanguages.Ar)]
    [InlineData(ParsingLanguages.As)]
    [InlineData(ParsingLanguages.Ava)]
    [InlineData(ParsingLanguages.Az)]
    [InlineData(ParsingLanguages.Be)]
    [InlineData(ParsingLanguages.Bg)]
    [InlineData(ParsingLanguages.Bgc)]
    [InlineData(ParsingLanguages.Bh)]
    [InlineData(ParsingLanguages.Bho)]
    [InlineData(ParsingLanguages.Bn)]
    [InlineData(ParsingLanguages.Bs)]
    [InlineData(ParsingLanguages.ChSim)]
    [InlineData(ParsingLanguages.ChTra)]
    [InlineData(ParsingLanguages.Che)]
    [InlineData(ParsingLanguages.Cs)]
    [InlineData(ParsingLanguages.Cy)]
    [InlineData(ParsingLanguages.Da)]
    [InlineData(ParsingLanguages.Dar)]
    [InlineData(ParsingLanguages.De)]
    [InlineData(ParsingLanguages.En)]
    [InlineData(ParsingLanguages.Es)]
    [InlineData(ParsingLanguages.Et)]
    [InlineData(ParsingLanguages.Fa)]
    [InlineData(ParsingLanguages.Fr)]
    [InlineData(ParsingLanguages.Ga)]
    [InlineData(ParsingLanguages.Gom)]
    [InlineData(ParsingLanguages.Hi)]
    [InlineData(ParsingLanguages.Hr)]
    [InlineData(ParsingLanguages.Hu)]
    [InlineData(ParsingLanguages.ID)]
    [InlineData(ParsingLanguages.Inh)]
    [InlineData(ParsingLanguages.Is)]
    [InlineData(ParsingLanguages.It)]
    [InlineData(ParsingLanguages.Ja)]
    [InlineData(ParsingLanguages.Kbd)]
    [InlineData(ParsingLanguages.Kn)]
    [InlineData(ParsingLanguages.Ko)]
    [InlineData(ParsingLanguages.Ku)]
    [InlineData(ParsingLanguages.La)]
    [InlineData(ParsingLanguages.Lbe)]
    [InlineData(ParsingLanguages.Lez)]
    [InlineData(ParsingLanguages.Lt)]
    [InlineData(ParsingLanguages.Lv)]
    [InlineData(ParsingLanguages.Mah)]
    [InlineData(ParsingLanguages.Mai)]
    [InlineData(ParsingLanguages.Mi)]
    [InlineData(ParsingLanguages.Mn)]
    [InlineData(ParsingLanguages.Mni)]
    [InlineData(ParsingLanguages.Mr)]
    [InlineData(ParsingLanguages.Ms)]
    [InlineData(ParsingLanguages.Mt)]
    [InlineData(ParsingLanguages.Ne)]
    [InlineData(ParsingLanguages.New)]
    [InlineData(ParsingLanguages.Nl)]
    [InlineData(ParsingLanguages.No)]
    [InlineData(ParsingLanguages.Oc)]
    [InlineData(ParsingLanguages.Pi)]
    [InlineData(ParsingLanguages.Pl)]
    [InlineData(ParsingLanguages.Pt)]
    [InlineData(ParsingLanguages.Ro)]
    [InlineData(ParsingLanguages.RsCyrillic)]
    [InlineData(ParsingLanguages.RsLatin)]
    [InlineData(ParsingLanguages.Ru)]
    [InlineData(ParsingLanguages.Sa)]
    [InlineData(ParsingLanguages.Sck)]
    [InlineData(ParsingLanguages.Sk)]
    [InlineData(ParsingLanguages.Sl)]
    [InlineData(ParsingLanguages.Sq)]
    [InlineData(ParsingLanguages.Sv)]
    [InlineData(ParsingLanguages.Sw)]
    [InlineData(ParsingLanguages.Ta)]
    [InlineData(ParsingLanguages.Tab)]
    [InlineData(ParsingLanguages.Te)]
    [InlineData(ParsingLanguages.Th)]
    [InlineData(ParsingLanguages.Tjk)]
    [InlineData(ParsingLanguages.Tl)]
    [InlineData(ParsingLanguages.Tr)]
    [InlineData(ParsingLanguages.Ug)]
    [InlineData(ParsingLanguages.Uk)]
    [InlineData(ParsingLanguages.Ur)]
    [InlineData(ParsingLanguages.Uz)]
    [InlineData(ParsingLanguages.Vi)]
    public void SerializationRoundtrip_Works(ParsingLanguages rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingLanguages> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingLanguages>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingLanguages>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingLanguages>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
