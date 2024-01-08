import React, { useState } from 'react';
import NavBar from '../../components/NavBar/NavBarAdm';
import './HomeStyle.css';


function Home() {

    return (
        <div>
            <NavBar>
            </NavBar>
            <div className="row container-fluid" style={{ width: '100vw' }}>
                <div className="col-12">
                    <div className="card">
                        <div className="row card-body">
                            <div className="col-1">
                            </div>
                            <div className="col-2">
                                <button className="btn btn-primary">TESTE</button>
                            </div>
                            <div className="col-2">
                                <button className="btn btn-primary">TESTE</button>
                            </div>
                            <div className="col-2">
                                <button className="btn btn-primary">TESTE</button>
                            </div>
                            <div className="col-2">
                                <button className="btn btn-primary">TESTE</button>
                            </div>
                            <div className="col-2">
                                <button className="btn btn-primary">TESTE</button>
                            </div>
                            <div className="col-1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Home;