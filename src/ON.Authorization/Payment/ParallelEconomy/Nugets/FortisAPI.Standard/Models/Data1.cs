// <copyright file="Data1.cs" company="APIMatic">
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
    using FortisAPI.Standard;
    using FortisAPI.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Data1.
    /// </summary>
    public class Data1
    {
        private string productTransactionId;
        private double? batchNum;
        private double? isOpen;
        private string settlementFileName;
        private double? batchCloseTs;
        private string batchCloseDetail;
        private double? totalSaleAmount;
        private double? totalSaleCount;
        private double? totalRefundAmount;
        private double? totalRefundCount;
        private double? totalVoidAmount;
        private double? totalVoidCount;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "product_transaction_id", false },
            { "batch_num", false },
            { "is_open", false },
            { "settlement_file_name", false },
            { "batch_close_ts", false },
            { "batch_close_detail", false },
            { "total_sale_amount", false },
            { "total_sale_count", false },
            { "total_refund_amount", false },
            { "total_refund_count", false },
            { "total_void_amount", false },
            { "total_void_count", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Data1"/> class.
        /// </summary>
        public Data1()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data1"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="processingStatusId">processing_status_id.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="batchNum">batch_num.</param>
        /// <param name="isOpen">is_open.</param>
        /// <param name="settlementFileName">settlement_file_name.</param>
        /// <param name="batchCloseTs">batch_close_ts.</param>
        /// <param name="batchCloseDetail">batch_close_detail.</param>
        /// <param name="totalSaleAmount">total_sale_amount.</param>
        /// <param name="totalSaleCount">total_sale_count.</param>
        /// <param name="totalRefundAmount">total_refund_amount.</param>
        /// <param name="totalRefundCount">total_refund_count.</param>
        /// <param name="totalVoidAmount">total_void_amount.</param>
        /// <param name="totalVoidCount">total_void_count.</param>
        public Data1(
            string id,
            int createdTs,
            int modifiedTs,
            double processingStatusId,
            string productTransactionId = null,
            double? batchNum = null,
            double? isOpen = null,
            string settlementFileName = null,
            double? batchCloseTs = null,
            string batchCloseDetail = null,
            double? totalSaleAmount = null,
            double? totalSaleCount = null,
            double? totalRefundAmount = null,
            double? totalRefundCount = null,
            double? totalVoidAmount = null,
            double? totalVoidCount = null)
        {
            this.Id = id;
            this.CreatedTs = createdTs;
            this.ModifiedTs = modifiedTs;
            if (productTransactionId != null)
            {
                this.ProductTransactionId = productTransactionId;
            }

            this.ProcessingStatusId = processingStatusId;
            if (batchNum != null)
            {
                this.BatchNum = batchNum;
            }

            if (isOpen != null)
            {
                this.IsOpen = isOpen;
            }

            if (settlementFileName != null)
            {
                this.SettlementFileName = settlementFileName;
            }

            if (batchCloseTs != null)
            {
                this.BatchCloseTs = batchCloseTs;
            }

            if (batchCloseDetail != null)
            {
                this.BatchCloseDetail = batchCloseDetail;
            }

            if (totalSaleAmount != null)
            {
                this.TotalSaleAmount = totalSaleAmount;
            }

            if (totalSaleCount != null)
            {
                this.TotalSaleCount = totalSaleCount;
            }

            if (totalRefundAmount != null)
            {
                this.TotalRefundAmount = totalRefundAmount;
            }

            if (totalRefundCount != null)
            {
                this.TotalRefundCount = totalRefundCount;
            }

            if (totalVoidAmount != null)
            {
                this.TotalVoidAmount = totalVoidAmount;
            }

            if (totalVoidCount != null)
            {
                this.TotalVoidCount = totalVoidCount;
            }

        }

        /// <summary>
        /// Batch ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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
        /// Product Transaction Id
        /// </summary>
        [JsonProperty("product_transaction_id")]
        public string ProductTransactionId
        {
            get
            {
                return this.productTransactionId;
            }

            set
            {
                this.shouldSerialize["product_transaction_id"] = true;
                this.productTransactionId = value;
            }
        }

        /// <summary>
        /// Processing Status Id
        /// </summary>
        [JsonProperty("processing_status_id")]
        public double ProcessingStatusId { get; set; }

        /// <summary>
        /// Batch Number
        /// </summary>
        [JsonProperty("batch_num")]
        public double? BatchNum
        {
            get
            {
                return this.batchNum;
            }

            set
            {
                this.shouldSerialize["batch_num"] = true;
                this.batchNum = value;
            }
        }

        /// <summary>
        /// Is Open
        /// </summary>
        [JsonProperty("is_open")]
        public double? IsOpen
        {
            get
            {
                return this.isOpen;
            }

            set
            {
                this.shouldSerialize["is_open"] = true;
                this.isOpen = value;
            }
        }

        /// <summary>
        /// Settlement File Name
        /// </summary>
        [JsonProperty("settlement_file_name")]
        public string SettlementFileName
        {
            get
            {
                return this.settlementFileName;
            }

            set
            {
                this.shouldSerialize["settlement_file_name"] = true;
                this.settlementFileName = value;
            }
        }

        /// <summary>
        /// Batch Close Ts
        /// </summary>
        [JsonProperty("batch_close_ts")]
        public double? BatchCloseTs
        {
            get
            {
                return this.batchCloseTs;
            }

            set
            {
                this.shouldSerialize["batch_close_ts"] = true;
                this.batchCloseTs = value;
            }
        }

        /// <summary>
        /// Batch Close Detail
        /// </summary>
        [JsonProperty("batch_close_detail")]
        public string BatchCloseDetail
        {
            get
            {
                return this.batchCloseDetail;
            }

            set
            {
                this.shouldSerialize["batch_close_detail"] = true;
                this.batchCloseDetail = value;
            }
        }

        /// <summary>
        /// Total Sale Amount
        /// </summary>
        [JsonProperty("total_sale_amount")]
        public double? TotalSaleAmount
        {
            get
            {
                return this.totalSaleAmount;
            }

            set
            {
                this.shouldSerialize["total_sale_amount"] = true;
                this.totalSaleAmount = value;
            }
        }

        /// <summary>
        /// Total Sale Count
        /// </summary>
        [JsonProperty("total_sale_count")]
        public double? TotalSaleCount
        {
            get
            {
                return this.totalSaleCount;
            }

            set
            {
                this.shouldSerialize["total_sale_count"] = true;
                this.totalSaleCount = value;
            }
        }

        /// <summary>
        /// Total Refund Amount
        /// </summary>
        [JsonProperty("total_refund_amount")]
        public double? TotalRefundAmount
        {
            get
            {
                return this.totalRefundAmount;
            }

            set
            {
                this.shouldSerialize["total_refund_amount"] = true;
                this.totalRefundAmount = value;
            }
        }

        /// <summary>
        /// Total Refund Count
        /// </summary>
        [JsonProperty("total_refund_count")]
        public double? TotalRefundCount
        {
            get
            {
                return this.totalRefundCount;
            }

            set
            {
                this.shouldSerialize["total_refund_count"] = true;
                this.totalRefundCount = value;
            }
        }

        /// <summary>
        /// Total Void Amount
        /// </summary>
        [JsonProperty("total_void_amount")]
        public double? TotalVoidAmount
        {
            get
            {
                return this.totalVoidAmount;
            }

            set
            {
                this.shouldSerialize["total_void_amount"] = true;
                this.totalVoidAmount = value;
            }
        }

        /// <summary>
        /// Total Void Count
        /// </summary>
        [JsonProperty("total_void_count")]
        public double? TotalVoidCount
        {
            get
            {
                return this.totalVoidCount;
            }

            set
            {
                this.shouldSerialize["total_void_count"] = true;
                this.totalVoidCount = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Data1 : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetProductTransactionId()
        {
            this.shouldSerialize["product_transaction_id"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBatchNum()
        {
            this.shouldSerialize["batch_num"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetIsOpen()
        {
            this.shouldSerialize["is_open"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetSettlementFileName()
        {
            this.shouldSerialize["settlement_file_name"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBatchCloseTs()
        {
            this.shouldSerialize["batch_close_ts"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetBatchCloseDetail()
        {
            this.shouldSerialize["batch_close_detail"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalSaleAmount()
        {
            this.shouldSerialize["total_sale_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalSaleCount()
        {
            this.shouldSerialize["total_sale_count"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalRefundAmount()
        {
            this.shouldSerialize["total_refund_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalRefundCount()
        {
            this.shouldSerialize["total_refund_count"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalVoidAmount()
        {
            this.shouldSerialize["total_void_amount"] = false;
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetTotalVoidCount()
        {
            this.shouldSerialize["total_void_count"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProductTransactionId()
        {
            return this.shouldSerialize["product_transaction_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatchNum()
        {
            return this.shouldSerialize["batch_num"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsOpen()
        {
            return this.shouldSerialize["is_open"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSettlementFileName()
        {
            return this.shouldSerialize["settlement_file_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatchCloseTs()
        {
            return this.shouldSerialize["batch_close_ts"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatchCloseDetail()
        {
            return this.shouldSerialize["batch_close_detail"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalSaleAmount()
        {
            return this.shouldSerialize["total_sale_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalSaleCount()
        {
            return this.shouldSerialize["total_sale_count"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalRefundAmount()
        {
            return this.shouldSerialize["total_refund_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalRefundCount()
        {
            return this.shouldSerialize["total_refund_count"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalVoidAmount()
        {
            return this.shouldSerialize["total_void_amount"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTotalVoidCount()
        {
            return this.shouldSerialize["total_void_count"];
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

            return obj is Data1 other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                this.CreatedTs.Equals(other.CreatedTs) &&
                this.ModifiedTs.Equals(other.ModifiedTs) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                this.ProcessingStatusId.Equals(other.ProcessingStatusId) &&
                ((this.BatchNum == null && other.BatchNum == null) || (this.BatchNum?.Equals(other.BatchNum) == true)) &&
                ((this.IsOpen == null && other.IsOpen == null) || (this.IsOpen?.Equals(other.IsOpen) == true)) &&
                ((this.SettlementFileName == null && other.SettlementFileName == null) || (this.SettlementFileName?.Equals(other.SettlementFileName) == true)) &&
                ((this.BatchCloseTs == null && other.BatchCloseTs == null) || (this.BatchCloseTs?.Equals(other.BatchCloseTs) == true)) &&
                ((this.BatchCloseDetail == null && other.BatchCloseDetail == null) || (this.BatchCloseDetail?.Equals(other.BatchCloseDetail) == true)) &&
                ((this.TotalSaleAmount == null && other.TotalSaleAmount == null) || (this.TotalSaleAmount?.Equals(other.TotalSaleAmount) == true)) &&
                ((this.TotalSaleCount == null && other.TotalSaleCount == null) || (this.TotalSaleCount?.Equals(other.TotalSaleCount) == true)) &&
                ((this.TotalRefundAmount == null && other.TotalRefundAmount == null) || (this.TotalRefundAmount?.Equals(other.TotalRefundAmount) == true)) &&
                ((this.TotalRefundCount == null && other.TotalRefundCount == null) || (this.TotalRefundCount?.Equals(other.TotalRefundCount) == true)) &&
                ((this.TotalVoidAmount == null && other.TotalVoidAmount == null) || (this.TotalVoidAmount?.Equals(other.TotalVoidAmount) == true)) &&
                ((this.TotalVoidCount == null && other.TotalVoidCount == null) || (this.TotalVoidCount?.Equals(other.TotalVoidCount) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedTs = {this.CreatedTs}");
            toStringOutput.Add($"this.ModifiedTs = {this.ModifiedTs}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId == string.Empty ? "" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.ProcessingStatusId = {this.ProcessingStatusId}");
            toStringOutput.Add($"this.BatchNum = {(this.BatchNum == null ? "null" : this.BatchNum.ToString())}");
            toStringOutput.Add($"this.IsOpen = {(this.IsOpen == null ? "null" : this.IsOpen.ToString())}");
            toStringOutput.Add($"this.SettlementFileName = {(this.SettlementFileName == null ? "null" : this.SettlementFileName == string.Empty ? "" : this.SettlementFileName)}");
            toStringOutput.Add($"this.BatchCloseTs = {(this.BatchCloseTs == null ? "null" : this.BatchCloseTs.ToString())}");
            toStringOutput.Add($"this.BatchCloseDetail = {(this.BatchCloseDetail == null ? "null" : this.BatchCloseDetail == string.Empty ? "" : this.BatchCloseDetail)}");
            toStringOutput.Add($"this.TotalSaleAmount = {(this.TotalSaleAmount == null ? "null" : this.TotalSaleAmount.ToString())}");
            toStringOutput.Add($"this.TotalSaleCount = {(this.TotalSaleCount == null ? "null" : this.TotalSaleCount.ToString())}");
            toStringOutput.Add($"this.TotalRefundAmount = {(this.TotalRefundAmount == null ? "null" : this.TotalRefundAmount.ToString())}");
            toStringOutput.Add($"this.TotalRefundCount = {(this.TotalRefundCount == null ? "null" : this.TotalRefundCount.ToString())}");
            toStringOutput.Add($"this.TotalVoidAmount = {(this.TotalVoidAmount == null ? "null" : this.TotalVoidAmount.ToString())}");
            toStringOutput.Add($"this.TotalVoidCount = {(this.TotalVoidCount == null ? "null" : this.TotalVoidCount.ToString())}");
        }
    }
}