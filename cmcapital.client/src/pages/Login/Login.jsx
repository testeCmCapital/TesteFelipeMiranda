/*import React from 'react';*/
import React, { useState } from 'react';
import './LoginStyle.css';
import logo from '../../assets/imgs/logo.png';
import SweetAlert from 'sweetalert2';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';


function Login() {

    const [login, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
 

    const handleLogin = async () => {

        if (login == '' || password == '') {
            SweetAlert.fire({
                title: 'Sign in',
                text: 'Login or password is empty...',
                confirmButtonColor: '#4ad295',
            });
        }
        else {
            try {
                const response = await axios.post(`https://localhost:7077/api/Aut?login=${login}&password=${password}`);
                const token  = response.data.result;
                localStorage.setItem('token', token);
                
                if (login == "adm") {
                    navigate('/HomeAdm')
                }
                else if (login == "Client1") {
                    navigate('/HomeClient')
                }

            } catch (error) {
                if (error.response.data == 'login or password invalid') {
                    SweetAlert.fire({
                        title: 'Sign in',
                        text: error.response.data,
                        confirmButtonColor: '#4ad295',
                    });
                }
            }
        }
    };

    const forgetPass = () => {
        SweetAlert.fire({
            title: 'Forget password',
            text: 'If you forget your password, please contact your system administrator for assistance.',
            confirmButtonColor: '#4ad295',
        });
    };

    return (
        <div className="row" style={{ width: '100vw' }}>
            <div className="col-6 text-center" style={{ height: '100vh' }}>
                <div className="col-12" style={{ height: '60vh', maxHeight: '100%' }}>
                    <img src={logo} alt="logo" className="img-fluid mx-auto d-block" style={{ objectFit: 'cover', height:'100vh' }}></img>
                </div>
            </div>
            <div className="col-6" style={{ marginTop: '30vh' }}>
                <div className="col-12 text-center" style={{ height: '10vh' }}>
                    <span className="text" style={{ fontSize: '45px' }}>
                        LOGIN
                    </span>
                </div>
                <div className="col-12 text-center mt-3">
                    <span className="text" style={{ color: "black", fontSize: "10px" }}>
                        Enter your credentials to access the system
                    </span>
                </div>
                <div className="col-12 d-flex align-items-center justify-content-center">
                    <div className="input-group mt-3 divInput" style={{ width: '30vw' }}>
                        <span className="input-group-text icon"><i className="fa-solid fa-user"></i></span>
                        <input
                            type="text"
                            className="form-control form-control-sm inputStyle"
                            id="username"
                            value={login}
                            onChange={(e) => setUsername(e.target.value)}
                            placeholder="Your Login"
                            required
                        />
                    </div>
                </div>
                <div className="col-12 d-flex align-items-center justify-content-center">
                    <div className="input-group mt-3 divInput" style={{ width: '30vw' }}>
                        <span className="input-group-text icon"><i className="fa-solid fa-lock"></i></span>
                        <input
                            type="password"
                            className="form-control form-control-sm inputStyle"
                            id="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            placeholder="Password"
                            required
                        />
                    </div>
                </div>
                <div className="col-12 text-center mt-2">
                    <a type="button"><span className="forgetPass" onClick={forgetPass}>Forget the password?</span></a>
                </div>
                <div className="col-12 d-flex align-items-center justify-content-center mt-3">
                    <button className="btn btn-primary" type="button" onClick={handleLogin}>Sign in</button>
                </div>
            </div>
        </div>
    );
}

export default Login;