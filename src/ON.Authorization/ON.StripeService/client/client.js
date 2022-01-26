var grpc = require('grpc')
const { v4: uuidv4 } = require('uuid')

// var services = require('../server/proto/dummy_grpc_pb')
var service = require('../server/proto/stripe_grpc_pb')
var StripeService = require('../server/proto/stripe_pb')

// TODO: Check typeof(data) === json
// function buildRequest(requestData) {
// 	return new StripeService.StripeRequest(requestData)
// }

function main() {
	// Define the client
	// TODO: Set port from env
	var client = new service.StripeServiceClient(
		'localhost:50051',
		grpc.credentials.createInsecure()
	)
}

main()
