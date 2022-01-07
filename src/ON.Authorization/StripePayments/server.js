const grpc = require('@grpc/grpc-js')
const path = require('path')
var protoLoader = require('@grpc/proto-loader')

const options = {
	keepCase: true,
	longs: String,
	enums: String,
	defaults: true,
	oneofs: true,
}
const CLAIMS_PATH = './proto/Authorization/Claims.proto'
var claimsDefinition = protoLoader.loadSync(CLAIMS_PATH, options)
var claimsProto = grpc.loadPackageDefinition(claimsDefinition)

const server = new grpc.Server()

server.bindAsync(
	'127.0.0.1:50051',
	grpc.ServerCredentials.createInsecure(),
	(error, port) => {
		if (error) console.error(error)
		console.log(`Server running at http://127.0.0.1:${port}`)
		server.start()
	}
)
