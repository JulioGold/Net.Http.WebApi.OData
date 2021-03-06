﻿namespace Net.Http.WebApi.Tests.OData.Query
{
    using Net.Http.WebApi.OData;
    using Net.Http.WebApi.OData.Query;
    using Xunit;

    public class ODataRawQueryOptionsTests
    {
        public class WhenCallingConstructorWithAllQueryOptions
        {
            private readonly ODataRawQueryOptions rawQueryOptions;

            public WhenCallingConstructorWithAllQueryOptions()
            {
                this.rawQueryOptions = new ODataRawQueryOptions(
                    "?$expand=*&$filter=Name eq 'Fred'&$format=json&$inlinecount=allpages&$orderby=Name&$select=Name,Id&$skip=10&$skiptoken=5&$top=25");
            }

            [Fact]
            public void ExpandShouldBeSet()
            {
                Assert.Equal("$expand=*", this.rawQueryOptions.Expand);
            }

            [Fact]
            public void FilterShouldBeSet()
            {
                Assert.Equal("$filter=Name eq 'Fred'", this.rawQueryOptions.Filter);
            }

            [Fact]
            public void FormatShouldBeSet()
            {
                Assert.Equal("$format=json", this.rawQueryOptions.Format);
            }

            [Fact]
            public void InlineCountShouldBeSet()
            {
                Assert.Equal("$inlinecount=allpages", this.rawQueryOptions.InlineCount);
            }

            [Fact]
            public void OrderByShouldBeSet()
            {
                Assert.Equal("$orderby=Name", this.rawQueryOptions.OrderBy);
            }

            [Fact]
            public void SelectShouldBeSet()
            {
                Assert.Equal("$select=Name,Id", this.rawQueryOptions.Select);
            }

            [Fact]
            public void SkipShouldBeSet()
            {
                Assert.Equal("$skip=10", this.rawQueryOptions.Skip);
            }

            [Fact]
            public void SkipTokenShouldBeSet()
            {
                Assert.Equal("$skiptoken=5", this.rawQueryOptions.SkipToken);
            }

            [Fact]
            public void TopShouldBeSet()
            {
                Assert.Equal("$top=25", this.rawQueryOptions.Top);
            }

            [Fact]
            public void ToStringShouldReturnTheOriginalQuery()
            {
                Assert.Equal(
                    "?$expand=*&$filter=Name eq 'Fred'&$format=json&$inlinecount=allpages&$orderby=Name&$select=Name,Id&$skip=10&$skiptoken=5&$top=25",
                    rawQueryOptions.ToString());
            }
        }

        public class WhenCallingConstructorWithAnUnknownQueryOptionWhichDoesNotStartsWithADollar
        {
            [Fact]
            public void AnODataExceptionShouldNotBeThrown()
            {
                Assert.DoesNotThrow(() => new ODataRawQueryOptions("wibble=*"));
            }
        }

        public class WhenCallingConstructorWithAnUnknownQueryOptionWhichStartsWithADollar
        {
            [Fact]
            public void AnODataExceptionShouldBeThrown()
            {
                var exception = Assert.Throws<ODataException>(() => new ODataRawQueryOptions("?$wibble=*"));

                Assert.Equal(string.Format(Messages.UnknownQueryOption, "$wibble=*"), exception.Message);
            }
        }

        public class WhenCallingConstructorWithNoQueryOptions
        {
            private readonly ODataRawQueryOptions rawQueryOptions;

            public WhenCallingConstructorWithNoQueryOptions()
            {
                this.rawQueryOptions = new ODataRawQueryOptions(string.Empty);
            }

            [Fact]
            public void ExpandShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Expand);
            }

            [Fact]
            public void FilterShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Filter);
            }

            [Fact]
            public void FormatShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Format);
            }

            [Fact]
            public void InlineCountShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.InlineCount);
            }

            [Fact]
            public void OrderByShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.OrderBy);
            }

            [Fact]
            public void SelectShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Select);
            }

            [Fact]
            public void SkipShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Skip);
            }

            [Fact]
            public void SkipTokenShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.SkipToken);
            }

            [Fact]
            public void TopShouldBeNull()
            {
                Assert.Null(this.rawQueryOptions.Top);
            }

            [Fact]
            public void ToStringShouldReturnEmpty()
            {
                Assert.Equal(string.Empty, rawQueryOptions.ToString());
            }
        }
    }
}