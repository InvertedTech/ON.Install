// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var proto_stripe_pb = require('../proto/stripe_pb.js');
var google_protobuf_timestamp_pb = require('google-protobuf/google/protobuf/timestamp_pb.js');

function serialize_CancelOwnSubscriptionRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.CancelOwnSubscriptionRequest)) {
    throw new Error('Expected argument of type CancelOwnSubscriptionRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_CancelOwnSubscriptionRequest(buffer_arg) {
  return proto_stripe_pb.CancelOwnSubscriptionRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_CancelOwnSubscriptionResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.CancelOwnSubscriptionResponse)) {
    throw new Error('Expected argument of type CancelOwnSubscriptionResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_CancelOwnSubscriptionResponse(buffer_arg) {
  return proto_stripe_pb.CancelOwnSubscriptionResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_GetAccountDetailsRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.GetAccountDetailsRequest)) {
    throw new Error('Expected argument of type GetAccountDetailsRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_GetAccountDetailsRequest(buffer_arg) {
  return proto_stripe_pb.GetAccountDetailsRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_GetAccountDetailsResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.GetAccountDetailsResponse)) {
    throw new Error('Expected argument of type GetAccountDetailsResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_GetAccountDetailsResponse(buffer_arg) {
  return proto_stripe_pb.GetAccountDetailsResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_GetOwnSubscriptionRecordRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.GetOwnSubscriptionRecordRequest)) {
    throw new Error('Expected argument of type GetOwnSubscriptionRecordRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_GetOwnSubscriptionRecordRequest(buffer_arg) {
  return proto_stripe_pb.GetOwnSubscriptionRecordRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_GetOwnSubscriptionRecordResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.GetOwnSubscriptionRecordResponse)) {
    throw new Error('Expected argument of type GetOwnSubscriptionRecordResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_GetOwnSubscriptionRecordResponse(buffer_arg) {
  return proto_stripe_pb.GetOwnSubscriptionRecordResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_NewOwnSubscriptionRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.NewOwnSubscriptionRequest)) {
    throw new Error('Expected argument of type NewOwnSubscriptionRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_NewOwnSubscriptionRequest(buffer_arg) {
  return proto_stripe_pb.NewOwnSubscriptionRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_NewOwnSubscriptionResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.NewOwnSubscriptionResponse)) {
    throw new Error('Expected argument of type NewOwnSubscriptionResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_NewOwnSubscriptionResponse(buffer_arg) {
  return proto_stripe_pb.NewOwnSubscriptionResponse.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_StripeInitRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.StripeInitRequest)) {
    throw new Error('Expected argument of type StripeInitRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_StripeInitRequest(buffer_arg) {
  return proto_stripe_pb.StripeInitRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_StripeInitResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.StripeInitResponse)) {
    throw new Error('Expected argument of type StripeInitResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_StripeInitResponse(buffer_arg) {
  return proto_stripe_pb.StripeInitResponse.deserializeBinary(new Uint8Array(buffer_arg));
}


var StripeInterfaceService = exports.StripeInterfaceService = {
  cancelOwnSubscription: {
    path: '/StripeInterface/CancelOwnSubscription',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.CancelOwnSubscriptionRequest,
    responseType: proto_stripe_pb.CancelOwnSubscriptionResponse,
    requestSerialize: serialize_CancelOwnSubscriptionRequest,
    requestDeserialize: deserialize_CancelOwnSubscriptionRequest,
    responseSerialize: serialize_CancelOwnSubscriptionResponse,
    responseDeserialize: deserialize_CancelOwnSubscriptionResponse,
  },
  getAccountDetails: {
    path: '/StripeInterface/GetAccountDetails',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.GetAccountDetailsRequest,
    responseType: proto_stripe_pb.GetAccountDetailsResponse,
    requestSerialize: serialize_GetAccountDetailsRequest,
    requestDeserialize: deserialize_GetAccountDetailsRequest,
    responseSerialize: serialize_GetAccountDetailsResponse,
    responseDeserialize: deserialize_GetAccountDetailsResponse,
  },
  getOwnSubscriptionRecord: {
    path: '/StripeInterface/GetOwnSubscriptionRecord',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.GetOwnSubscriptionRecordRequest,
    responseType: proto_stripe_pb.GetOwnSubscriptionRecordResponse,
    requestSerialize: serialize_GetOwnSubscriptionRecordRequest,
    requestDeserialize: deserialize_GetOwnSubscriptionRecordRequest,
    responseSerialize: serialize_GetOwnSubscriptionRecordResponse,
    responseDeserialize: deserialize_GetOwnSubscriptionRecordResponse,
  },
  newOwnSubscription: {
    path: '/StripeInterface/NewOwnSubscription',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.NewOwnSubscriptionRequest,
    responseType: proto_stripe_pb.NewOwnSubscriptionResponse,
    requestSerialize: serialize_NewOwnSubscriptionRequest,
    requestDeserialize: deserialize_NewOwnSubscriptionRequest,
    responseSerialize: serialize_NewOwnSubscriptionResponse,
    responseDeserialize: deserialize_NewOwnSubscriptionResponse,
  },
  stripeInitiate: {
    path: '/StripeInterface/StripeInitiate',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.StripeInitRequest,
    responseType: proto_stripe_pb.StripeInitResponse,
    requestSerialize: serialize_StripeInitRequest,
    requestDeserialize: deserialize_StripeInitRequest,
    responseSerialize: serialize_StripeInitResponse,
    responseDeserialize: deserialize_StripeInitResponse,
  },
};

exports.StripeInterfaceClient = grpc.makeGenericClientConstructor(StripeInterfaceService);
