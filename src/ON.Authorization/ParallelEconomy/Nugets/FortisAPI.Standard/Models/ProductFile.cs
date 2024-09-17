// <copyright file="ProductFile.cs" company="APIMatic">
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
    /// ProductFile.
    /// </summary>
    public class ProductFile : BaseModel
    {
        private double? freeBytes;
        private double? byteIncrement;
        private double? maxFileSizeBytes;
        private double? incrementCost;
        private int? monthlyFee;
        private string fileExtAllowed;
        private string container;
        private int? createdTs;
        private int? modifiedTs;
        private string createdUserId;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "free_bytes", false },
            { "byte_increment", false },
            { "max_file_size_bytes", false },
            { "increment_cost", false },
            { "monthly_fee", false },
            { "file_ext_allowed", false },
            { "container", false },
            { "created_ts", false },
            { "modified_ts", false },
            { "created_user_id", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFile"/> class.
        /// </summary>
        public ProductFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFile"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="productFileCredentialId">product_file_credential_id.</param>
        /// <param name="id">id.</param>
        /// <param name="active">active.</param>
        /// <param name="freeBytes">free_bytes.</param>
        /// <param name="byteIncrement">byte_increment.</param>
        /// <param name="maxFileSizeBytes">max_file_size_bytes.</param>
        /// <param name="incrementCost">increment_cost.</param>
        /// <param name="monthlyFee">monthly_fee.</param>
        /// <param name="fileExtAllowed">file_ext_allowed.</param>
        /// <param name="container">container.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="createdUserId">created_user_id.</param>
        public ProductFile(
            string title,
            string productFileCredentialId,
            string id,
            bool active,
            double? freeBytes = null,
            double? byteIncrement = null,
            double? maxFileSizeBytes = null,
            double? incrementCost = null,
            int? monthlyFee = null,
            string fileExtAllowed = null,
            string container = null,
            int? createdTs = null,
            int? modifiedTs = null,
            string createdUserId = null)
        {
            this.Title = title;
            this.ProductFileCredentialId = productFileCredentialId;
            if (freeBytes != null)
            {
                this.FreeBytes = freeBytes;
            }

            if (byteIncrement != null)
            {
                this.ByteIncrement = byteIncrement;
            }

            if (maxFileSizeBytes != null)
            {
                this.MaxFileSizeBytes = maxFileSizeBytes;
            }

            if (incrementCost != null)
            {
                this.IncrementCost = incrementCost;
            }

            if (monthlyFee != null)
            {
                this.MonthlyFee = monthlyFee;
            }

            if (fileExtAllowed != null)
            {
                this.FileExtAllowed = fileExtAllowed;
            }

            if (container != null)
            {
                this.Container = container;
            }

            this.Id = id;
            if (createdTs != null)
            {
                this.CreatedTs = createdTs;
            }

            if (modifiedTs != null)
            {
                this.ModifiedTs = modifiedTs;
            }

            this.Active = active;
            if (createdUserId != null)
            {
                this.CreatedUserId = createdUserId;
            }

        }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Product File Credential Id
        /// </summary>
        [JsonProperty("product_file_credential_id")]
        public string ProductFileCredentialId { get; set; }

        /// <summary>
        /// Free Bytes
        /// </summary>
        [JsonProperty("free_bytes")]
        public double? FreeBytes
        {
            get
            {
                return this.freeBytes;
            }

            set
            {
                this.shouldSerialize["free_bytes"] = true;
                this.freeBytes = value;
            }
        }

        /// <summary>
        /// Byte Increment
        /// </summary>
        [JsonProperty("byte_increment")]
        public double? ByteIncrement
        {
            get
            {
                return this.byteIncrement;
            }

            set
            {
                this.shouldSerialize["byte_increment"] = true;
                this.byteIncrement = value;
            }
        }

        /// <summary>
        /// Max File Size Bytes
        /// </summary>
        [JsonProperty("max_file_size_bytes")]
        public double? MaxFileSizeBytes
        {
            get
            {
                return this.maxFileSizeBytes;
            }

            set
            {
                this.shouldSerialize["max_file_size_bytes"] = true;
                this.maxFileSizeBytes = value;
            }
        }

        /// <summary>
        /// Increment Cost
        /// </summary>
        [JsonProperty("increment_cost")]
        public double? IncrementCost
        {
            get
            {
                return this.incrementCost;
            }

            set
            {
                this.shouldSerialize["increment_cost"] = true;
                this.incrementCost = value;
            }
        }

        /// <summary>
        /// Monthly Fee
        /// </summary>
        [JsonProperty("monthly_fee")]
        public int? MonthlyFee
        {
            get
            {
                return this.monthlyFee;
            }

            set
            {
                this.shouldSerialize["monthly_fee"] = true;
                this.monthlyFee = value;
            }
        }

        /// <summary>
        /// File Ext Allowed
        /// </summary>
        [JsonProperty("file_ext_allowed")]
        public string FileExtAllowed
        {
            get
            {
                return this.fileExtAllowed;
            }

            set
            {
                this.shouldSerialize["file_ext_allowed"] = true;
                this.fileExtAllowed = value;
            }
        }

        /// <summary>
        /// Container
        /// </summary>
        [JsonProperty("container")]
        public string Container
        {
            get
            {
                return this.container;
            }

            set
            {
                this.shouldSerialize["container"] = true;
                this.container = value;
            }
        }

        /// <summary>
        /// Product File Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts")]
        public int? CreatedTs
        {
            get
            {
                return this.createdTs;
            }

            set
            {
                this.shouldSerialize["created_ts"] = true;
                this.createdTs = value;
            }
        }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts")]
        public int? ModifiedTs
        {
            get
            {
                return this.modifiedTs;
            }

            set
            {
                this.shouldSerialize["modified_ts"] = true;
                this.modifiedTs = value;
            }
        }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

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

            return $"ProductFile : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFreeBytes()
        {
            this.shouldSerialize["free_bytes"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetByteIncrement()
        {
            this.shouldSerialize["byte_increment"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMaxFileSizeBytes()
        {
            this.shouldSerialize["max_file_size_bytes"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIncrementCost()
        {
            this.shouldSerialize["increment_cost"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetMonthlyFee()
        {
            this.shouldSerialize["monthly_fee"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetFileExtAllowed()
        {
            this.shouldSerialize["file_ext_allowed"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetContainer()
        {
            this.shouldSerialize["container"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetCreatedTs()
        {
            this.shouldSerialize["created_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetModifiedTs()
        {
            this.shouldSerialize["modified_ts"] = false;
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
        public bool ShouldSerializeFreeBytes()
        {
            return this.shouldSerialize["free_bytes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeByteIncrement()
        {
            return this.shouldSerialize["byte_increment"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMaxFileSizeBytes()
        {
            return this.shouldSerialize["max_file_size_bytes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIncrementCost()
        {
            return this.shouldSerialize["increment_cost"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMonthlyFee()
        {
            return this.shouldSerialize["monthly_fee"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFileExtAllowed()
        {
            return this.shouldSerialize["file_ext_allowed"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeContainer()
        {
            return this.shouldSerialize["container"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCreatedTs()
        {
            return this.shouldSerialize["created_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifiedTs()
        {
            return this.shouldSerialize["modified_ts"];
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
            return obj is ProductFile other &&                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.ProductFileCredentialId == null && other.ProductFileCredentialId == null) || (this.ProductFileCredentialId?.Equals(other.ProductFileCredentialId) == true)) &&
                ((this.FreeBytes == null && other.FreeBytes == null) || (this.FreeBytes?.Equals(other.FreeBytes) == true)) &&
                ((this.ByteIncrement == null && other.ByteIncrement == null) || (this.ByteIncrement?.Equals(other.ByteIncrement) == true)) &&
                ((this.MaxFileSizeBytes == null && other.MaxFileSizeBytes == null) || (this.MaxFileSizeBytes?.Equals(other.MaxFileSizeBytes) == true)) &&
                ((this.IncrementCost == null && other.IncrementCost == null) || (this.IncrementCost?.Equals(other.IncrementCost) == true)) &&
                ((this.MonthlyFee == null && other.MonthlyFee == null) || (this.MonthlyFee?.Equals(other.MonthlyFee) == true)) &&
                ((this.FileExtAllowed == null && other.FileExtAllowed == null) || (this.FileExtAllowed?.Equals(other.FileExtAllowed) == true)) &&
                ((this.Container == null && other.Container == null) || (this.Container?.Equals(other.Container) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                this.Active.Equals(other.Active) &&
                ((this.CreatedUserId == null && other.CreatedUserId == null) || (this.CreatedUserId?.Equals(other.CreatedUserId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title)}");
            toStringOutput.Add($"this.ProductFileCredentialId = {(this.ProductFileCredentialId == null ? "null" : this.ProductFileCredentialId)}");
            toStringOutput.Add($"this.FreeBytes = {(this.FreeBytes == null ? "null" : this.FreeBytes.ToString())}");
            toStringOutput.Add($"this.ByteIncrement = {(this.ByteIncrement == null ? "null" : this.ByteIncrement.ToString())}");
            toStringOutput.Add($"this.MaxFileSizeBytes = {(this.MaxFileSizeBytes == null ? "null" : this.MaxFileSizeBytes.ToString())}");
            toStringOutput.Add($"this.IncrementCost = {(this.IncrementCost == null ? "null" : this.IncrementCost.ToString())}");
            toStringOutput.Add($"this.MonthlyFee = {(this.MonthlyFee == null ? "null" : this.MonthlyFee.ToString())}");
            toStringOutput.Add($"this.FileExtAllowed = {(this.FileExtAllowed == null ? "null" : this.FileExtAllowed)}");
            toStringOutput.Add($"this.Container = {(this.Container == null ? "null" : this.Container)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.Active = {this.Active}");
            toStringOutput.Add($"this.CreatedUserId = {(this.CreatedUserId == null ? "null" : this.CreatedUserId)}");

            base.ToString(toStringOutput);
        }
    }
}