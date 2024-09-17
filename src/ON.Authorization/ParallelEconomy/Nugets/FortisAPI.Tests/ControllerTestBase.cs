// <copyright file="ControllerTestBase.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FortisAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Types;
    using FortisAPI.Standard;
    using FortisAPI.Standard.Authentication;
    using FortisAPI.Standard.Http.Client;
    using FortisAPI.Standard.Models;
    using FortisAPI.Standard.Models.Containers;
    using NUnit.Framework;

    /// <summary>
    /// ControllerTestBase Class.
    /// </summary>
    [TestFixture]
    public class ControllerTestBase
    {
        /// <summary>
        /// Assert precision.
        /// </summary>
        protected const double AssertPrecision = 0.1;

        /// <summary>
        /// Gets HttpCallBackHandler.
        /// </summary>
        internal HttpCallBack HttpCallBack { get; private set; } = new HttpCallBack();

        /// <summary>
        /// Gets FortisAPIClient Client.
        /// </summary>
        protected FortisAPIClient Client { get; private set; }

        /// <summary>
        /// Set up the client.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            FortisAPIClient config = FortisAPIClient.CreateFromEnvironment();
            this.Client = config.ToBuilder()
                .HttpCallBack(HttpCallBack)
                .Build();
        }
    }
}