// <copyright file="Sort.cs" company="APIMatic">
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
    /// Sort.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort"/> class.
        /// </summary>
        public Sort()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sort"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdTs">created_ts.</param>
        /// <param name="modifiedTs">modified_ts.</param>
        /// <param name="productTransactionId">product_transaction_id.</param>
        /// <param name="processingStatusId">processing_status_id.</param>
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
        public Sort(
            string id = null,
            int? createdTs = null,
            int? modifiedTs = null,
            string productTransactionId = null,
            double? processingStatusId = null,
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
            this.ProductTransactionId = productTransactionId;
            this.ProcessingStatusId = processingStatusId;
            this.BatchNum = batchNum;
            this.IsOpen = isOpen;
            this.SettlementFileName = settlementFileName;
            this.BatchCloseTs = batchCloseTs;
            this.BatchCloseDetail = batchCloseDetail;
            this.TotalSaleAmount = totalSaleAmount;
            this.TotalSaleCount = totalSaleCount;
            this.TotalRefundAmount = totalRefundAmount;
            this.TotalRefundCount = totalRefundCount;
            this.TotalVoidAmount = totalVoidAmount;
            this.TotalVoidCount = totalVoidCount;
        }

        /// <summary>
        /// Batch ID
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Created Time Stamp
        /// </summary>
        [JsonProperty("created_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? CreatedTs { get; set; }

        /// <summary>
        /// Modified Time Stamp
        /// </summary>
        [JsonProperty("modified_ts", NullValueHandling = NullValueHandling.Ignore)]
        public int? ModifiedTs { get; set; }

        /// <summary>
        /// Product Transaction Id
        /// </summary>
        [JsonProperty("product_transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTransactionId { get; set; }

        /// <summary>
        /// Processing Status Id
        /// </summary>
        [JsonProperty("processing_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public double? ProcessingStatusId { get; set; }

        /// <summary>
        /// Batch Number
        /// </summary>
        [JsonProperty("batch_num", NullValueHandling = NullValueHandling.Ignore)]
        public double? BatchNum { get; set; }

        /// <summary>
        /// Is Open
        /// </summary>
        [JsonProperty("is_open", NullValueHandling = NullValueHandling.Ignore)]
        public double? IsOpen { get; set; }

        /// <summary>
        /// Settlement File Name
        /// </summary>
        [JsonProperty("settlement_file_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SettlementFileName { get; set; }

        /// <summary>
        /// Batch Close Ts
        /// </summary>
        [JsonProperty("batch_close_ts", NullValueHandling = NullValueHandling.Ignore)]
        public double? BatchCloseTs { get; set; }

        /// <summary>
        /// Batch Close Detail
        /// </summary>
        [JsonProperty("batch_close_detail", NullValueHandling = NullValueHandling.Ignore)]
        public string BatchCloseDetail { get; set; }

        /// <summary>
        /// Total Sale Amount
        /// </summary>
        [JsonProperty("total_sale_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalSaleAmount { get; set; }

        /// <summary>
        /// Total Sale Count
        /// </summary>
        [JsonProperty("total_sale_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalSaleCount { get; set; }

        /// <summary>
        /// Total Refund Amount
        /// </summary>
        [JsonProperty("total_refund_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalRefundAmount { get; set; }

        /// <summary>
        /// Total Refund Count
        /// </summary>
        [JsonProperty("total_refund_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalRefundCount { get; set; }

        /// <summary>
        /// Total Void Amount
        /// </summary>
        [JsonProperty("total_void_amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalVoidAmount { get; set; }

        /// <summary>
        /// Total Void Count
        /// </summary>
        [JsonProperty("total_void_count", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalVoidCount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sort : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sort other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedTs == null && other.CreatedTs == null) || (this.CreatedTs?.Equals(other.CreatedTs) == true)) &&
                ((this.ModifiedTs == null && other.ModifiedTs == null) || (this.ModifiedTs?.Equals(other.ModifiedTs) == true)) &&
                ((this.ProductTransactionId == null && other.ProductTransactionId == null) || (this.ProductTransactionId?.Equals(other.ProductTransactionId) == true)) &&
                ((this.ProcessingStatusId == null && other.ProcessingStatusId == null) || (this.ProcessingStatusId?.Equals(other.ProcessingStatusId) == true)) &&
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
            toStringOutput.Add($"this.CreatedTs = {(this.CreatedTs == null ? "null" : this.CreatedTs.ToString())}");
            toStringOutput.Add($"this.ModifiedTs = {(this.ModifiedTs == null ? "null" : this.ModifiedTs.ToString())}");
            toStringOutput.Add($"this.ProductTransactionId = {(this.ProductTransactionId == null ? "null" : this.ProductTransactionId == string.Empty ? "" : this.ProductTransactionId)}");
            toStringOutput.Add($"this.ProcessingStatusId = {(this.ProcessingStatusId == null ? "null" : this.ProcessingStatusId.ToString())}");
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