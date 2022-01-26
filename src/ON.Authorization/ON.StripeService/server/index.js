var grpc = require('grpc')
const { v4: uuidv4 } = require('uuid')

var service = require('../server/proto/stripe_grpc_pb')
var StripeService = require('../server/proto/stripe_pb')
const writeBuffer = require('./utils/writeBuffer')

function writeData(call, callback) {
	let req = call.request.serializeBinary()

	var response = new StripeService.StripeResponse()
	response.setResponsemessage('server response')

	writeBuffer(req, 'stored.pb')

	callback(null, response)
}

function main() {
	var server = new grpc.Server()

	server.addService(service.StripeServiceService, {
		writeStripeData: writeData,
	})
	server.bind('127.0.0.1:50051', grpc.ServerCredentials.createInsecure())
	server.start()

	console.log('Server running on port 127.0.0.1:50051')
}

main()
