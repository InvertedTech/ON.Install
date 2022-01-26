#!/bin/bash

protoc -I=. ./proto/Stripe/*.proto --js_out=import_style=commonjs,binary:./server --grpc_out=./server --plugin=protoc-gen-grpc=./node_modules/grpc-tools/bin/grpc_node_plugin.exe