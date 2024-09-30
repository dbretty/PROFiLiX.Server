using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PROFiLiX.Web.Shared.Common;
using PROFiLiX.Web.Shared.Models;

namespace PROFiLiX.Web.Shared.Tests.Common
{
    [TestFixture]
    public class ProfilixUserProfileTests
    {
        [Test]
        public void FormatFileSize_WithValidSmallData_ShouldSucceed()
        {
            // Arrange
            IProfilixUserProfile profilixUserProfile = new ProfilixUserProfile();

            // Act
            var fileSize = profilixUserProfile.FormatFileSize(1);

            // Assert
            Assert.That(fileSize, Is.EqualTo("1 B"));

        }

        [Test]
        public void FormatFileSize_WithValidLargeData_ShouldSucceed()
        {
            // Arrange
            IProfilixUserProfile profilixUserProfile = new ProfilixUserProfile();

            // Act
            var fileSize = profilixUserProfile.FormatFileSize(1_000_000_000);

            // Assert
            Assert.That(fileSize, Is.EqualTo("953.67 MB"));

        }
    }
}
