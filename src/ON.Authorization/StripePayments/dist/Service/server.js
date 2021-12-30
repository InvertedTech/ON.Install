"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var tslib_1 = require("tslib");
var path_1 = (0, tslib_1.__importDefault)(require("path"));
var grpc = (0, tslib_1.__importStar)(require("@grpc/grpc-js"));
var protoLoader = (0, tslib_1.__importStar)(require("@grpc/proto-loader"));
var PORT = process.env.PORT || 3000;
var PROTO_FILE = '../Proto/payment.proto';
var packageDef = protoLoader.loadSync(path_1.default.resolve(__dirname, PROTO_FILE));
var grpcObj = grpc.loadPackageDefinition(packageDef);
var paymentPackage = grpcObj.paymentPackage;
function main() {
    var server = getServer();
    server.bindAsync("0.0.0.0:".concat(PORT), grpc.ServerCredentials.createInsecure(), function (err, port) {
        if (err) {
            console.error(err);
            return;
        }
        console.log("Server started on port:".concat(port));
        server.start();
    });
}
function getServer() {
    var server = new grpc.Server();
    server.addService(paymentPackage.Payment.service, {
        PingPong: function (req, res) {
            console.log(req.request);
            res(null, { message: 'Pong' });
        },
    });
    return server;
}
main();
