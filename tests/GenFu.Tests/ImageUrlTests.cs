using GenFu.Fillers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenFu.Tests
{
    class Profile : Person
    {
        public string AvatarUrl { get; set; }
    }

    public class ImageUrlTests
    {
        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeight()
        {
            
            A.Configure<Profile>()
                .Fill(p => p.AvatarUrl)
                .AsPlaceholderImage(width: 300, height: 400);

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400";
            Assert.True(johnDoe.AvatarUrl == expected);
        }

        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeightText()
        {
            A.Configure<Profile>()
                .Fill(p => p.AvatarUrl)
                .AsPlaceholderImage(width: 300, height: 400, text: "Sample");

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400?text=Sample";
            Assert.True(johnDoe.AvatarUrl == expected);
        }

        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeightPngFormat()
        {
            A.Configure<Profile>()
                .Fill(p => p.AvatarUrl)
                .AsPlaceholderImage(width: 300, height: 400, format: ImgFormat.PNG);

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400.PNG";
            Assert.True(johnDoe.AvatarUrl == expected);
        }

        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeightColor()
        {
            A.Configure<Profile>()
                          .Fill(p => p.AvatarUrl)
                          .AsPlaceholderImage(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000");

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400/000000/FFFFFF";
            Assert.True(johnDoe.AvatarUrl == expected);
        }

        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeightColorText()
        {
            A.Configure<Profile>()
                          .Fill(p => p.AvatarUrl)
                          .AsPlaceholderImage(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000", text: "Sample");

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400/000000/FFFFFF?text=Sample";
            Assert.True(johnDoe.AvatarUrl == expected);
        }

        [Fact]
        public void ShouldCreateImgTagUsingWidthAndHeightColorTextFormat()
        {
            A.Configure<Profile>()
                          .Fill(p => p.AvatarUrl)
                          .AsPlaceholderImage(width: 300, height: 400, textColor: "FFFFFF", backgroundColor: "000000", text: "Sample", format: ImgFormat.PNG);

            var johnDoe = A.New<Profile>();

            //assert
            string expected = @"http://placehold.it/300x400.PNG/000000/FFFFFF?text=Sample";
            Assert.True(johnDoe.AvatarUrl == expected);

        }

    }
}
