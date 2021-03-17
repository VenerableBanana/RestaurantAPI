using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Models.Validatiors
{
    public class RestaurantQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSizes = new[] {5, 10, 15};

        private string[] allowedSordByColumnNames =
            {nameof(Restaurant.Name), nameof(Restaurant.Desctiprion), nameof(Restaurant.Category)};
        public RestaurantQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });
            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSordByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSordByColumnNames)}]");
        }
    }
}
