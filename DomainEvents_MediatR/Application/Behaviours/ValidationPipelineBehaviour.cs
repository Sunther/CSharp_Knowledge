using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DomainEvents_MediatR.Application.Behaviours;

internal class ValidationPipelineBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _Validators;

    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _Validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_Validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_Validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
                throw new ValidationException(failures);
        }

        //var error = _Validators.Select(validator => validator.Validate(request))
        //                        .SelectMany(validationResult => validationResult.Errors);

        //if (error.Any())
        //{
        //    throw new ValidationException(CreateValidationResult(error));
        //}

        return await next();
    }

    private static IEnumerable<string> CreateValidationResult(IEnumerable<ValidationFailure> errors)
    {
        return errors.Select(s => $"{s.PropertyName} - {s.ErrorMessage}");
    }
}
