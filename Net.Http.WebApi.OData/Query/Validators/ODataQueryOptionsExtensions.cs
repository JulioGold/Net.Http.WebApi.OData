﻿// -----------------------------------------------------------------------
// <copyright file="ODataQueryOptionsExtensions.cs" company="Project Contributors">
// Copyright 2012 - 2015 Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace Net.Http.WebApi.OData.Query.Validators
{
    using Net.Http.WebApi.OData.Query;

    /// <summary>
    /// Extension methods for validating the <see cref="ODataQueryOptions"/>
    /// </summary>
    public static class ODataQueryOptionsExtensions
    {
        /// <summary>
        /// Validates the specified query options.
        /// </summary>
        /// <param name="queryOptions">The query options.</param>
        /// <param name="validationSettings">The validation settings.</param>
        public static void Validate(this ODataQueryOptions queryOptions, ODataValidationSettings validationSettings)
        {
            ODataQueryOptionsValidator.Validate(queryOptions, validationSettings);
            SkipQueryOptionValidator.Validate(queryOptions);
            TopQueryOptionValidator.Validate(queryOptions, validationSettings);
        }
    }
}