import { useState } from 'react';
import { api } from '../services/api';

export default function Login() {
const [user, setU] = useState('');
const [pass, setP] = useState('');
const login = async () => {
const res = await api.post('/auth/api/auth/login', { username: user, password: pass });
alert('token: ' + res.data.token);
};
return (
<div>
<h2>Login</h2>
<input name="username" placeholder="user" onChange={e => setU(e.target.value)} />
<input name="password" placeholder="pass" type="password" onChange={e => setP(e.target.value)} />
<button onClick={login}>Login</button>
</div>
);
}