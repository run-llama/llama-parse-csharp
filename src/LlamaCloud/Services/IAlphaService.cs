using System;
using LlamaCloud.Core;
using LlamaCloud.Services.Alpha;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAlphaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAlphaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlphaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVerifyService Verify { get; }
}

/// <summary>
/// A view of <see cref="IAlphaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAlphaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlphaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IVerifyServiceWithRawResponse Verify { get; }
}
