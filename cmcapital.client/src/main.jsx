import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import Login from './pages/Login/Login';
import './index.css'
import SweetAlert from 'sweetalert2';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomeAdm from './pages/Home/HomeAdm.jsx';
import HomeClient from './pages/Home/HomeClient.jsx';

ReactDOM.createRoot(document.getElementById('root')).render(
    <Router>
        <Routes>
            <Route path="/" element={<App />} />
            <Route path="/HomeAdm" element={<HomeAdm />} />
            <Route path="/HomeClient" element={<HomeClient />} />
        </Routes>
    </Router>
)
