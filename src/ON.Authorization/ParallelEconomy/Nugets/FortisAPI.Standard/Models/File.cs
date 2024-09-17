// <copyright file="File.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// File.
    /// </summary>
    public class File : BaseModel
    {
        private string productFileId;
        private string fileCategoryId;
        private string visibilityGroupId;
        private string fileDescription;
        private string fileName;
        private string fileExtension;
        private int? fileSizeBytes;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "product_file_id", false },
            { "file_category_id", false },
            { "visibility_group_id", false },
            { "file_description", false },
            { "file_name", false },
            { "file_extension", false },
            { "file_size_bytes", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        public File()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        /// <param name="fileProp">file.</param>
        /// <param name="resourceId">resource_id.</param>
        /// <param name="resource">resource.</param>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="productFileId">product_file_id.</param>
        /// <param name="fileCategoryId">file_category_id.</param>
        /// <param name="visibilityGroupId">visibility_group_id.</param>
        /// <param name="fileDescription">file_description.</param>
        /// <param name="fileName">file_name.</param>
        /// <param name="fileExtension">file_extension.</param>
        /// <param name="fileSizeBytes">file_size_bytes.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public File(
            object fileProp,
            string resourceId,
            Models.Resource2Enum resource,
            string id,
            int createdTs,
            int modifiedTs,
            string productFileId = null,
            string fileCategoryId = null,
            string visibilityGroupId = null,
            string fileDescription = null,
            string fileName = null,
            string fileExtension = null,
            int? fileSizeBytes = null,
            string createdUserId = null)
        {
            this.FileProp = fileProp;
            this.ResourceId = resourceId;
            this.Resource = resource;
            if (productFileId != null)
            {
                this.ProductFileId = productFileId;
            }

            if (fileCategoryId != null)
            {
                this.FileCategoryId = fileCategoryId;
            }

            if (visibilityGroupId != null)
            {
                this.VisibilityGroupId = visibilityGroupId;
            }

            if (fileDescription != null)
            {
                this.FileDescription = fileDescription;
            }

            this.Id = id;
            if (fileName != null)
            {
                this.FileName = fileName;
            }

            if (fileExtension != null)
            {
                this.FileExtension = fileExtension;
            }

            if (fileSizeBytes != null)
            {
                this.FileSizeBytes = fileSizeBytes;
            }

            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// File Object
        /// </summary>
        [JsonProperty("file")]
        public object FileProp { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Resource
        /// </summary>
        [JsonProperty("resource")]
        public Models.Resource2Enum Resource { get; set; }

        /// <summary>
        /// Product File Id
        /// </summary>
        [JsonProperty("product_file_id")]
        public string ProductFileId
        {
            get
            {
                return this.productFileId;
            }

            set
            {
                this.shouldSerialize["product_file_id"] = true;
                this.productFileId = value;
            }
        }

        /// <summary>
        /// File Category Id
        /// </summary>
        [JsonProperty("file_category_id")]
        public string FileCategoryId
        {
            get
            {
                return this.fileCategoryId;
            }

            set
            {
                this.shouldSerialize["file_category_id"] = true;
                this.fileCategoryId = value;
            }
        }

        /// <summary>
        /// Visibility Group Id
        /// </summary>
        [JsonProperty("visibility_group_id")]
        public string VisibilityGroupId
        {
            get
            {
                return this.visibilityGroupId;
            }

            set
            {
                this.shouldSerialize["visibility_group_id"] = true;
                this.visibilityGroupId = value;
            }
        }

        /// <summary>
        /// File Description
        /// </summary>
        [JsonProperty("file_description")]
        public string FileDescription
        {
            get
            {
                return this.fileDescription;
            }

            set
            {
                this.shouldSerialize["file_description"] = true;
                this.fileDescription = value;
            }
        }

        /// <summary>
        /// Resource
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.shouldSerialize["file_name"] = true;
                this.fileName = value;
            }
        }

        /// <summary>
        /// File Extension
        /// </summary>
        [JsonProperty("file_extension")]
        public string FileExtension
        {
            get
            {
                return this.fileExtension;
            }

            set
            {
                this.shouldSerialize["file_extension"] = true;
                this.fileExtension = value;
            }
        }

        /// <summary>
        /// File Size Bytes
        /// </summary>
        [JsonProperty("file_size_bytes")]
        public int? FileSizeBytes
        {
            get
            {
                return this.fileSizeBytes;
            }

            set
            {
                this.shouldSerialize["file_size_bytes"] = true;
                this.fileSizeBytes = value;
            }
        }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int ModifiedTs { get; set; }

        /// <summary>
        /// User ID Created the register
        /// </summary>
        [JsonProperty("created_user_id")]
        public string CreatedUserId
        {
            get
            {
                return this.createdUserId;
            }

            set
            {
                this.shouldSerialize["created_user_id"] = true;
                this.createdUserId = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"File : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductFileId()
        {
            this.shouldSerialize["product_file_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileCategoryId()
        {
            this.shouldSerialize["file_category_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetVisibilityGroupId()
        {
            this.shouldSerialize["visibility_group_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileDescription()
        {
            this.shouldSerialize["file_description"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileName()
        {
            this.shouldSerialize["file_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileExtension()
        {
            this.shouldSerialize["file_extension"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileSizeBytes()
        {
            this.shouldSerialize["file_size_bytes"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedUserId()
        {
            this.shouldSerialize["created_user_id"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductFileId()
        {
            return this.shouldSerialize["product_file_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileCategoryId()
        {
            return this.shouldSerialize["file_category_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVisibilityGroupId()
        {
            return this.shouldSerialize["visibility_group_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileDescription()
        {
            return this.shouldSerialize["file_description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileName()
        {
            return this.shouldSerialize["file_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileExtension()
        {
            return this.shouldSerialize["file_extension"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileSizeBytes()
        {
            return this.shouldSerialize["file_size_bytes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedUserId()
        {
            return this.shouldSerialize["created_user_id"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is File other &&                ((this.FileProp == null && other.FileProp == null) || (this.FileProp?.Equals(other.FileProp) == true)) &&
                ((this.ResourceId == null && other.ResourceId == null) || (this.ResourceId?.Equals(other.ResourceId) == true)) &&
                this.Resource.Equals(other.Resource) &&
                ((this.ProductFileId == null && other.ProductFileId == null) || (this.ProductFileId?.Equals(other.ProductFileId) == true)) &&
                ((this.FileCategoryId == null && other.FileCategoryId == null) || (this.FileCategoryId?.Equals(other.FileCategoryId) == true)) &&
                ((this.VisibilityGroupId == null && other.VisibilityGroupId == null) || (this.VisibilityGroupId?.Equals(other.VisibilityGroupId) == true)) &&
                ((this.FileDescription == null && other.FileDescription == null) || (this.FileDescription?.Equals(other.FileDescription) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.FileName == null && other.FileName == null) || (this.FileName?.Equals(other.FileName) == true)) &&
                ((this.FileExtension == null && other.FileExtension == null) || (this.FileExtension?.Equals(other.FileExtension) == true)) &&
                ((this.FileSizeBytes == null && other.FileSizeBytes == null) || (this.FileSizeBytes?.Equals(other.FileSizeBytes) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"FileProp = {(this.FileProp == null ? "null" : this.FileProp.ToString())}");
            toStringOutput.Add($"this.ResourceId = {(this.ResourceId == null ? "null" : this.ResourceId)}");
            toStringOutput.Add($"this.Resource = {this.Resource}");
            toStringOutput.Add($"this.ProductFileId = {(this.ProductFileId == null ? "null" : this.ProductFileId)}");
            toStringOutput.Add($"this.FileCategoryId = {(this.FileCategoryId == null ? "null" : this.FileCategoryId)}");
            toStringOutput.Add($"this.VisibilityGroupId = {(this.VisibilityGroupId == null ? "null" : this.VisibilityGroupId)}");
            toStringOutput.Add($"this.FileDescription = {(this.FileDescription == null ? "null" : this.FileDescription)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.FileName = {(this.FileName == null ? "null" : this.FileName)}");
            toStringOutput.Add($"this.FileExtension = {(this.FileExtension == null ? "null" : this.FileExtension)}");
            toStringOutput.Add($"this.FileSizeBytes = {(this.FileSizeBytes == null ? "null" : this.FileSizeBytes.ToString())}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}