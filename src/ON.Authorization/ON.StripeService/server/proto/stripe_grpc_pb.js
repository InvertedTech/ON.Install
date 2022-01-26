// GENERATED CODE -- DO NOT EDIT!

'use strict';
var grpc = require('grpc');
var proto_stripe_pb = require('../proto/stripe_pb.js');
var google_protobuf_empty_pb = require('google-protobuf/google/protobuf/empty_pb.js');

function serialize_google_protobuf_Empty(arg) {
  if (!(arg instanceof google_protobuf_empty_pb.Empty)) {
    throw new Error('Expected argument of type google.protobuf.Empty');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_google_protobuf_Empty(buffer_arg) {
  return google_protobuf_empty_pb.Empty.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_stripe_StripeData(arg) {
  if (!(arg instanceof proto_stripe_pb.StripeData)) {
    throw new Error('Expected argument of type stripe.StripeData');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_stripe_StripeData(buffer_arg) {
  return proto_stripe_pb.StripeData.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_stripe_StripeRequest(arg) {
  if (!(arg instanceof proto_stripe_pb.StripeRequest)) {
    throw new Error('Expected argument of type stripe.StripeRequest');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_stripe_StripeRequest(buffer_arg) {
  return proto_stripe_pb.StripeRequest.deserializeBinary(new Uint8Array(buffer_arg));
}

function serialize_stripe_StripeResponse(arg) {
  if (!(arg instanceof proto_stripe_pb.StripeResponse)) {
    throw new Error('Expected argument of type stripe.StripeResponse');
  }
  return Buffer.from(arg.serializeBinary());
}

function deserialize_stripe_StripeResponse(buffer_arg) {
  return proto_stripe_pb.StripeResponse.deserializeBinary(new Uint8Array(buffer_arg));
}


// protoc -I=. ./proto/*.proto --js_out=import_style=commonjs,binary:./server --grpc_out=./server --plugin=protoc-gen-grpc=./node_modules/grpc-tools/bin/grpc_node_plugin.exe
// TODO: Lock services behind auth
// TODO: Define CRUD operations for all StripeData items
var StripeServiceService = exports.StripeServiceService = {
  writeStripeData: {
    path: '/stripe.StripeService/WriteStripeData',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.StripeRequest,
    responseType: proto_stripe_pb.StripeResponse,
    requestSerialize: serialize_stripe_StripeRequest,
    requestDeserialize: deserialize_stripe_StripeRequest,
    responseSerialize: serialize_stripe_StripeResponse,
    responseDeserialize: deserialize_stripe_StripeResponse,
  },
  readStripeData: {
    path: '/stripe.StripeService/ReadStripeData',
    requestStream: false,
    responseStream: false,
    requestType: google_protobuf_empty_pb.Empty,
    responseType: proto_stripe_pb.StripeData,
    requestSerialize: serialize_google_protobuf_Empty,
    requestDeserialize: deserialize_google_protobuf_Empty,
    responseSerialize: serialize_stripe_StripeData,
    responseDeserialize: deserialize_stripe_StripeData,
  },
  updateStripeData: {
    path: '/stripe.StripeService/UpdateStripeData',
    requestStream: false,
    responseStream: false,
    requestType: proto_stripe_pb.StripeData,
    responseType: google_protobuf_empty_pb.Empty,
    requestSerialize: serialize_stripe_StripeData,
    requestDeserialize: deserialize_stripe_StripeData,
    responseSerialize: serialize_google_protobuf_Empty,
    responseDeserialize: deserialize_google_protobuf_Empty,
  },
};

exports.StripeServiceClient = grpc.makeGenericClientConstructor(StripeServiceService);
