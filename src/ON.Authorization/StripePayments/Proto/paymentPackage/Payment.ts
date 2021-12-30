// Original file: proto/payment.proto

import type * as grpc from '@grpc/grpc-js'
import type { MethodDefinition } from '@grpc/proto-loader'
import type { PingRequest as _paymentPackage_PingRequest, PingRequest__Output as _paymentPackage_PingRequest__Output } from '../paymentPackage/PingRequest';
import type { PongResponse as _paymentPackage_PongResponse, PongResponse__Output as _paymentPackage_PongResponse__Output } from '../paymentPackage/PongResponse';

export interface PaymentClient extends grpc.Client {
  PingPong(argument: _paymentPackage_PingRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  PingPong(argument: _paymentPackage_PingRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  PingPong(argument: _paymentPackage_PingRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  PingPong(argument: _paymentPackage_PingRequest, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  pingPong(argument: _paymentPackage_PingRequest, metadata: grpc.Metadata, options: grpc.CallOptions, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  pingPong(argument: _paymentPackage_PingRequest, metadata: grpc.Metadata, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  pingPong(argument: _paymentPackage_PingRequest, options: grpc.CallOptions, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  pingPong(argument: _paymentPackage_PingRequest, callback: grpc.requestCallback<_paymentPackage_PongResponse__Output>): grpc.ClientUnaryCall;
  
}

export interface PaymentHandlers extends grpc.UntypedServiceImplementation {
  PingPong: grpc.handleUnaryCall<_paymentPackage_PingRequest__Output, _paymentPackage_PongResponse>;
  
}

export interface PaymentDefinition extends grpc.ServiceDefinition {
  PingPong: MethodDefinition<_paymentPackage_PingRequest, _paymentPackage_PongResponse, _paymentPackage_PingRequest__Output, _paymentPackage_PongResponse__Output>
}
