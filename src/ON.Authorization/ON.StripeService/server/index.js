var grpc = require('grpc')

var service = require('../server/proto/stripe_grpc_pb')
var StripeService = require('../server/proto/stripe_pb')
const writeBuffer = require('./utils/writeBuffer')

function main() {
	var server = new grpc.Server()

	server.bind('127.0.0.1:50051', grpc.ServerCredentials.createInsecure())
	server.start()

	console.log('Server running on port 127.0.0.1:50051')
}

main()
