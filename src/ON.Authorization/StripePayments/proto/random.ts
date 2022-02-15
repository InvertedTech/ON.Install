import type * as grpc from '@grpc/grpc-js';
import type { ServiceDefinition, EnumTypeDefinition, MessageTypeDefinition } from '@grpc/proto-loader';

import type { ChatServiceClient as _randomPackage_ChatServiceClient, ChatServiceDefinition as _randomPackage_ChatServiceDefinition } from './randomPackage/ChatService';

type SubtypeConstructor<Constructor extends new (...args: any) => any, Subtype> = {
  new(...args: ConstructorParameters<Constructor>): Subtype;
};

export interface ProtoGrpcType {
  google: {
    protobuf: {
      Empty: MessageTypeDefinition
    }
  }
  randomPackage: {
    ChatService: SubtypeConstructor<typeof grpc.Client, _randomPackage_ChatServiceClient> & { service: _randomPackage_ChatServiceDefinition }
    InitiateRequest: MessageTypeDefinition
    InitiateResponse: MessageTypeDefinition
    MessageRequest: MessageTypeDefinition
    Status: EnumTypeDefinition
    StreamMessage: MessageTypeDefinition
    StreamRequest: MessageTypeDefinition
    User: MessageTypeDefinition
    UserStreamResponse: MessageTypeDefinition
  }
}

