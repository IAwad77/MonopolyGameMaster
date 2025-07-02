import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import App from './pages/Home.jsx';
import Login from './pages/Login.jsx';
import Game from './pages/Game.jsx';
import Upload from './pages/Upload.jsx';
import Property from './pages/Property.jsx';
import Bank from './pages/Bank.jsx';

ReactDOM.createRoot(document.getElementById('root')).render(
<BrowserRouter>
<Routes>
<Route path="/" element={<App />} />
<Route path="/login" element={<Login />} />
<Route path="/game" element={<Game />} />
<Route path="/upload" element={<Upload />} />
<Route path="/property" element={<Property />} />
<Route path="/bank" element={<Bank />} />
</Routes>
</BrowserRouter>
);