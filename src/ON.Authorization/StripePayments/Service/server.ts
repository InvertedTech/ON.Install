import path from 'path'
import * as grpc from '@grpc/grpc-js'
import * as protoLoader from '@grpc/proto-loader'
import { ProtoGrpcType } from '../Proto/payment'
import { PaymentHandlers } from '../Proto/paymentPackage/Payment'

const PORT = process.env.PORT || 3000
const PROTO_FILE = '../Proto/payment.proto'

const packageDef = protoLoader.loadSync(path.resolve(__dirname, PROTO_FILE))
const grpcObj = grpc.loadPackageDefinition(
	packageDef
) as unknown as ProtoGrpcType
const paymentPackage = grpcObj.paymentPackage

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

			console.log(`Server started on port:${port}`)
			server.start()
		}
	)
}

function getServer() {
	const server = new grpc.Server()

	server.addService(paymentPackage.Payment.service, {
		PingPong: (req, res) => {
			console.log(req.request)
			res(null, { message: 'Pong' })
		},
	} as PaymentHandlers)

	return server
}

main()
