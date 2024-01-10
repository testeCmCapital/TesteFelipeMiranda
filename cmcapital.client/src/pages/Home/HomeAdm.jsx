import React, { useState, useEffect } from 'react';
import NavBar from '../../components/NavBar/NavBarAdm';
import axios from 'axios';
import './HomeStyle.css';


function Home() {

    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {

            const token = localStorage.getItem('token');

            try {
                const response = await axios.get('https://localhost:7077/api/Purchases/PurchaseHistory', {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });

                const newData = response.data.map(item => {
                    const clientName = Object.keys(item)[0];
                    const clientData = item[clientName];

                    return {
                        client: clientData.client,
                        product: clientData.product,
                        quantities: clientData.quantities,
                        purchaseValue: clientData.purchaseValue,
                        purchaseDate: clientData.purchaseDate,
                        id: clientData.id,
                    };
                });

                setData(newData);


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
            <div className="row container-fluid" style={{ width: '100vw' }}>
                <div className="col-12 text-center mt-5">
                    <h1 className="text">Purchase Historic</h1>
                </div>
                <div className="col-12" style={{ marginTop: '100px', colo: '' }}>
                    <table className="table text-center">
                        <thead >
                            <tr>
                                <th scope="col">Client</th>
                                <th scope="col">Product</th>
                                <th scope="col">Quantities</th>
                                <th scope="col">Purchase Value</th>
                                <th scope="col">Purchase Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            {data.map((item) => (
                                <tr key={item.id}>
                                    <td>{item.client}</td>
                                    <td>{item.product}</td>
                                    <td>{item.quantities}</td>
                                    <td>{item.purchaseValue}</td>
                                    <td>{item.purchaseDate}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default Home;