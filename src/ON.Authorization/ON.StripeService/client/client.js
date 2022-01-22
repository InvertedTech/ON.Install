var grpc = require('grpc')

var services = require('../server/proto/dummy_grpc_pb')

function main() {
	console.log('Hello from the client!')
	var client = new services.DummyServiceClient(
		'localhost:50051',
		grpc.credentials.createInsecure()
	)

	// Do Stuff!
}

main()
