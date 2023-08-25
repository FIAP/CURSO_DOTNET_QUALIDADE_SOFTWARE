using API.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Tests.Infra
{
    public class HelperTests
    {

        [Fact]
        public void Should_return_Validate_Slug()
        {
            //Arrange
            var title = "Fim de ano da Band traz programas especiais, filmes e shows exclusivos";

            //Act
            var slug = Helper.GenerateSlug(title);

            //Assert
            Assert.Equal("fim-de-ano-da-band-traz-programas-especiais-filmes-e-shows-exclusivos", slug);

        }
    }
}
