import type * as grpc from '@grpc/grpc-js';
import type { MessageTypeDefinition } from '@grpc/proto-loader';

import type { PaymentClient as _paymentPackage_PaymentClient, PaymentDefinition as _paymentPackage_PaymentDefinition } from './paymentPackage/Payment';

type SubtypeConstructor<Constructor extends new (...args: any) => any, Subtype> = {
  new(...args: ConstructorParameters<Constructor>): Subtype;
};

export interface ProtoGrpcType {
  paymentPackage: {
    Payment: SubtypeConstructor<typeof grpc.Client, _paymentPackage_PaymentClient> & { service: _paymentPackage_PaymentDefinition }
    PingRequest: MessageTypeDefinition
    PongResponse: MessageTypeDefinition
  }
}

