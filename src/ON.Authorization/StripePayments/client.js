const grpc = require('@grpc/grpc-js')
const path = require('path')
const { v4: uuidv4 } = require('uuid')

const options = {
	keepCase: true,
	longs: String,
	enums: String,
	defaults: true,
	oneofs: true,
}

// TODO: Refactor
var protoLoader = require('@grpc/proto-loader')
const SUBSCRIPTION_PATH = './proto/Authorization/Subscription.proto'
var subscriptionDefinition = protoLoader.loadSync(SUBSCRIPTION_PATH, options)
var subscriptionProto = grpc.loadPackageDefinition(subscriptionDefinition)
var SubscriptionService =
	subscriptionProto.ON.Fragments.Authorization.SubscriptionService

const client = new SubscriptionService(
	'127.0.0.1:50051',
	grpc.credentials.createInsecure()
)

// TODO: Create calls
console.log(client.getAll)

// module.exports = client;
