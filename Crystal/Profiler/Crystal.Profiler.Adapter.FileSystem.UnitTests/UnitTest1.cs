using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crystal.Profiler.Data;
using System.Collections.Generic;
using Crystal.Provider.Adapter.FileSystem;
using Crystal.Core;

namespace Crystal.Profiler.Adapter.FileSystem.UnitTests
{
    [TestClass]
    public class CyProfilerAdapterFileSystemUnitTests
    {
        [TestMethod]
        public void CanListProfiles()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanSaveAndLoadProfile()
        {
            var dummyProfile = new CyProfile
            {
                Header = new CyProfileHeader
                {
                    DestinationEntity = "Person",
                    DestinationModule = "CM",
                    Group = "Customers",
                    Name = "Customer Application Form",
                    Status = CyProfileStatus.Active,
                    Version = 2,
                },
            };

            for (int pageNumber = 1; pageNumber <= 4; pageNumber++)
            {
                var dummyImage = new CyProfileImage
                {
                    Name = "Application Page " + pageNumber,
                    SizePixels = new CySize(3000, 2000)
                };
                dummyProfile.Images.Add(dummyImage);
            }

            var dummyTemplate = new CyProfileTemplate
            {
                DestinationTable = "CustomerApplications",
                Name = "Header"
            };

            // Create test files in the current folder
            ICyProfileAdapter adapter = new CyProfileAdapterFileSystem("");

            // Save the profile to a file in the current folder
            adapter.SaveProfile(dummyProfile);

            // Load the same file we just saved
            var loadedProfile = adapter.LoadProfile(dummyProfile.Header.Name);

            // Verify the template was saved and loaded correctly
            Assert.IsTrue(dummyProfile.Matches(loadedProfile));
        }
    }
}
