import React, { useState, useEffect } from 'react';
import NavBar from '../../components/NavBar/NavBarClient';
import axios from 'axios';
import './HomeStyle.css';


function Home() {
    const [dataClient, setDataClient] = useState([]);
    const [dataProduct, setProduct] = useState([]);


    useEffect(() => {
        const fetchData = async () => {

            const token = localStorage.getItem('token');

            try {
                //passei o id direto pq só tem um client no sistema e é gerenciado isso no login 
                //(só existe o client 1 no sistema mas é possivel mudar isso com pequenas alterações)
                const responseDataClient = await axios.get('https://localhost:7077/api/Client/Client/1', {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });

                const responseDataProduct = await axios.get('https://localhost:7077/api/Client/Client/1', {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });

                setDataClient(responseDataClient.data);

                console.log(responseDataClient.data)

            } catch (error) {
                console.error('Erro ao buscar dados da API', error);
            }
        };

        fetchData();
    }, []);


    return (
        <div>
            <NavBar>
            </NavBar>
            <div className="m-5">
                <div className="col-12">
                    <div className="col-12 text-center">
                        <h3 className="text">Buy product</h3>
                    </div>
                    <div className="col-12 text-end mt-3">
                        <span className="text" style={{fontSize:'14px'}}>Balance: </span>
                    </div>
                    <div className="col-12 mt-5 row">
                        <div className="col-4">
                            <label>Product</label>
                            <select className="form-select" aria-label="Default select example">
                                <option selected>Select product</option>
                                <option value="1">One</option>
                                <option value="2">Two</option>
                                <option value="3">Three</option>
                            </select>
                        </div>
                        <div className="col-4">
                            <label>Amount</label>
                            <input type="text" className="form-control" placeholder="Amount"/>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div className="col-12 text-center">
                        <span className="text">Purchase Value: <b>R$3000</b></span>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Home;