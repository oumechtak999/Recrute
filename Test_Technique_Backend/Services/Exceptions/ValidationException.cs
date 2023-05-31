﻿using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
namespace Test_Technique_Backend.Services.Exceptions
{
    public class ValidationException: ApplicationException
    {

        public List<string> ValdationErrors { get; set; }
        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
