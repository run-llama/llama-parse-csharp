using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Services.Extract;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IReviewServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Turn review on for an extract job.</para>
    ///
    /// <para>Fields read below `confidence_threshold`, and required fields left empty,
    /// are flagged for a person to check. Every setting has a default, so the body can
    /// be left out. A job still running can be named: it waits for review once it
    /// completes. A job that failed or was cancelled without a review, or that cannot
    /// be reviewed, answers 409 with `code: job_not_reviewable`; a field in
    /// `fields_in_scope` the job's schema does not have answers 400.</para>
    ///
    /// <para>Answers 201 with the new review, or 200 with the job's existing review,
    /// whose settings stay as they are.</para>
    /// </summary>
    Task<ExtractReview> Create(
        ReviewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ReviewCreateParams, CancellationToken)"/>
    Task<ExtractReview> Create(
        string jobID,
        ReviewCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Approve the reviewed result.</para>
    ///
    /// <para>While flagged fields nobody checked remain, answers 409 with `code:
    /// open_flags` and their `paths`, unless `sign_off` confirms them as part of
    /// approving. A job that has not completed answers 409 with `code:
    /// job_not_reviewable`. A `revision` other than the review's latest answers 409
    /// with `code: stale_revision` and the latest `revision`.</para>
    /// </summary>
    Task<ExtractReview> Approve(
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(ReviewApproveParams, CancellationToken)"/>
    Task<ExtractReview> Approve(
        string jobID,
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Confirm, correct, clear, restore or undo fields of a completed job.</para>
    ///
    /// <para>The changes apply in order, in one write. A job without a review gets one
    /// with the default settings, at revision 0. A path that is not a field of the job,
    /// or a value the field's schema refuses, answers 400 and changes nothing. A job
    /// that has not completed answers 409 with `code: job_not_reviewable`. A `revision`
    /// other than the review's latest answers 409 with `code: stale_revision` and the
    /// latest `revision`.</para>
    /// </summary>
    Task<ExtractReview> ChangeFields(
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChangeFields(ReviewChangeFieldsParams, CancellationToken)"/>
    Task<ExtractReview> ChangeFields(
        string jobID,
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Get an extract job's review: its flags, field actions and decision, with
    /// the result as the model read it and as reviewed. A job without a review answers
    /// 404.</para>
    /// </summary>
    Task<ExtractReview> Get(
        ReviewGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ReviewGetParams, CancellationToken)"/>
    Task<ExtractReview> Get(
        string jobID,
        ReviewGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>List a review's history, newest first.</para>
    /// </summary>
    Task<ReviewListEventsPage> ListEvents(
        ReviewListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(ReviewListEventsParams, CancellationToken)"/>
    Task<ReviewListEventsPage> ListEvents(
        string jobID,
        ReviewListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Reject the result, with a reason. A job that failed or was cancelled can
    /// be rejected, which closes a review turned on while it ran. A job still queued or
    /// running answers 409 with `code: job_not_reviewable`. A `revision` other than the
    /// review's latest answers 409 with `code: stale_revision` and the latest
    /// `revision`.</para>
    /// </summary>
    Task<ExtractReview> Reject(
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reject(ReviewRejectParams, CancellationToken)"/>
    Task<ExtractReview> Reject(
        string jobID,
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Beta: answers 403 until extract review is enabled for the caller and their
    /// organization.
    ///
    /// <para>Put an approved or rejected review back to pending. Its field actions
    /// stay.</para>
    ///
    /// <para>A `revision` other than the review's latest answers 409 with `code:
    /// stale_revision` and the latest `revision`.</para>
    /// </summary>
    Task<ExtractReview> Reopen(
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reopen(ReviewReopenParams, CancellationToken)"/>
    Task<ExtractReview> Reopen(
        string jobID,
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IReviewService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IReviewServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.Create(ReviewCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> Create(
        ReviewCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ReviewCreateParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> Create(
        string jobID,
        ReviewCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/review/approve</c>, but is otherwise the
    /// same as <see cref="IReviewService.Approve(ReviewApproveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> Approve(
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Approve(ReviewApproveParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> Approve(
        string jobID,
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/review/fields</c>, but is otherwise the
    /// same as <see cref="IReviewService.ChangeFields(ReviewChangeFieldsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> ChangeFields(
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChangeFields(ReviewChangeFieldsParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> ChangeFields(
        string jobID,
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/extract/{job_id}/review</c>, but is otherwise the
    /// same as <see cref="IReviewService.Get(ReviewGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> Get(
        ReviewGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ReviewGetParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> Get(
        string jobID,
        ReviewGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/extract/{job_id}/review/events</c>, but is otherwise the
    /// same as <see cref="IReviewService.ListEvents(ReviewListEventsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ReviewListEventsPage>> ListEvents(
        ReviewListEventsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEvents(ReviewListEventsParams, CancellationToken)"/>
    Task<HttpResponse<ReviewListEventsPage>> ListEvents(
        string jobID,
        ReviewListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/review/reject</c>, but is otherwise the
    /// same as <see cref="IReviewService.Reject(ReviewRejectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> Reject(
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reject(ReviewRejectParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> Reject(
        string jobID,
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/review/reopen</c>, but is otherwise the
    /// same as <see cref="IReviewService.Reopen(ReviewReopenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractReview>> Reopen(
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Reopen(ReviewReopenParams, CancellationToken)"/>
    Task<HttpResponse<ExtractReview>> Reopen(
        string jobID,
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    );
}
