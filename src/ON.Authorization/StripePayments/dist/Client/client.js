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
var client = new grpcObj.paymentPackage.Payment("0.0.0.0:".concat(PORT), grpc.credentials.createInsecure());
var deadline = new Date();
deadline.setSeconds(deadline.getSeconds() + 5);
client.waitForReady(deadline, function (err) {
    if (err) {
        console.error(err);
        return;
    }
    onClientReady();
});
function onClientReady() {
    client.PingPong({ message: 'Ping' }, function (err, res) {
        if (err) {
            console.error(err);
            return;
        }
        console.log(res);
    });
}
