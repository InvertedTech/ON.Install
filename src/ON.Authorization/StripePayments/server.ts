import path from 'path'
import * as grpc from '@grpc/grpc-js'
import * as protoLoader from '@grpc/proto-loader'
import { ProtoGrpcType } from './proto/random'
import { ChatServiceHandlers } from './proto/randomPackage/ChatService'

const PORT = 8082
const PROTO_FILE = './proto/random.proto'

const packageDef = protoLoader.loadSync(path.resolve(__dirname, PROTO_FILE))
const grpcObj = grpc.loadPackageDefinition(
	packageDef
) as unknown as ProtoGrpcType
const randomPackage = grpcObj.randomPackage

function main() {
	const server = getServer()

	server.bindAsync(
		`0.0.0.0:${PORT}`,
		grpc.ServerCredentials.createInsecure(),
		(err, port) => {
			if (err) {
				console.error(err)
				return
			}
			console.log(`Your server as started on port ${port}`)
			server.start()
		}
	)
}

// const callObjByUsername = new Map<
// 	string,
// 	grpc.ServerDuplexStream<ChatRequest, ChatResponse>
// >()

function getServer() {
	const server = new grpc.Server()
	server.addService(randomPackage.ChatService.service, {
		ChatInitiate: (call, callback) => {
			const sessionName = call.request.name || ' '
			const avatar = call.request.avatarUrl || ' '

			console.log('hey')
			if (!sessionName || !avatar)
				return callback(new Error('Name and avatar required'))

			callback(null, { id: Math.floor(Math.random() * 10000) })
		},
	} as ChatServiceHandlers)

	return server
}

main()
