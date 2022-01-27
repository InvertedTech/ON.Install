import React, { useEffect } from 'react'
import logo from './logo.svg'
import './App.css'
import { InitiateRequest } from './proto/random_pb'
import { ChatServiceClient } from './proto/RandomServiceClientPb'

function App() {
	useEffect(() => {
		;(async () => {
			const client = new ChatServiceClient('http://localhost:8080')
			const req = new InitiateRequest()
			req.setName('andrew')
			req.setAvatarUrl('test')
			client.chatInitiate(req, {})

			await client.chatInitiate(req, {}, (err, resp) => {
				console.log(resp.toObject())
			})
		})()
	}, [])

	return (
		<div className='App'>
			<header className='App-header'>
				<img src={logo} className='App-logo' alt='logo' />
				<p>
					Edit <code>src/App.tsx</code> and save to reload.
				</p>
				<a
					className='App-link'
					href='https://reactjs.org'
					target='_blank'
					rel='noopener noreferrer'
				>
					Learn React
				</a>
			</header>
		</div>
	)
}

export default App
