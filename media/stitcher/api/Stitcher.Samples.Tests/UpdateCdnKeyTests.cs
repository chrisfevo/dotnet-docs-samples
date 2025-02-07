/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Xunit;

namespace Stitcher.Samples.Tests
{
    [Collection(nameof(StitcherFixture))]
    public class UpdateCdnKeyTest
    {
        private StitcherFixture _fixture;
        private readonly UpdateCdnKeySample _updateSample;

        public UpdateCdnKeyTest(StitcherFixture fixture)
        {
            _fixture = fixture;
            _updateSample = new UpdateCdnKeySample();
        }

        [Fact]
        public void UpdatesCdnKey_MediaCdn()
        {
            var result = _updateSample.UpdateCdnKey(_fixture.ProjectId, _fixture.LocationId, _fixture.TestCloudCdnKeyId, _fixture.UpdatedMediaCdnHostname, _fixture.KeyName, _fixture.MediaCdnPrivateKey, true);
            Assert.Equal(_fixture.TestCloudCdnKeyId, result.CdnKeyName.CdnKeyId);
            Assert.Equal(_fixture.UpdatedMediaCdnHostname, result.Hostname);
        }

        [Fact]
        public void UpdatesCdnKey_CloudCdn()
        {
            var result = _updateSample.UpdateCdnKey(_fixture.ProjectId, _fixture.LocationId, _fixture.TestCloudCdnKeyId, _fixture.UpdatedCloudCdnHostname, _fixture.KeyName, _fixture.CloudCdnPrivateKey, false);
            Assert.Equal(_fixture.TestCloudCdnKeyId, result.CdnKeyName.CdnKeyId);
            Assert.Equal(_fixture.UpdatedCloudCdnHostname, result.Hostname);
        }
    }
}