import { useState } from 'react';
import { api } from '../services/api';

export default function Game() {
const [player, setPlayer] = useState('Ali');
const [state, setS] = useState('');
const start = () => api.post('/gamelogic/api/gamelogic/start', ['Ali', 'Sara']);
const end = async () => {
await api.post('/gamelogic/api/gamelogic/endturn');
const s = await api.get('/gamelogic/api/gamelogic');
setS(s.data.currentPlayer);
};
return (
<div>
<h2>Current: {state||player}</h2>
<button onClick={start}>Start</button>
<button onClick={end}>End Turn</button>
</div>
);
}