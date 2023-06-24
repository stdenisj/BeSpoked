import { Alert, Snackbar } from '@mui/material';
import React, { PropsWithChildren, useState } from 'react';
import { CoolServerError, CoolValidationError } from '../Services/server/WebClient';

interface AlertContext {
    success: (message: string) => void;
    error: (message: string) => void;
    serverError: (serverError: CoolServerError) => void;
    validationError: (serverError: CoolValidationError) => void;
}

const AlertReactContext = React.createContext<AlertContext>({} as AlertContext);

export function useAlert(): AlertContext {
    return React.useContext(AlertReactContext);
}

export function AlertProvider(props: PropsWithChildren<{}>){

    const [snackbarOpen, setSnackbarOpen] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState<"success" | "warning" | "error">("success");

    const handleClose = (event?: React.SyntheticEvent | Event, reason?: string) => {
        if (reason === 'clickaway') {
            return;
        }
        setSnackbarOpen(false);
    }

    const success = (message: string) =>{
        setSnackbarSeverity("success");
        setSnackbarMessage(message);
        setSnackbarOpen(true);
    }
    const error = (message: string) =>{
        setSnackbarSeverity("error");
        setSnackbarMessage(message);
        setSnackbarOpen(true);
    }
    const serverError = (serverError: CoolServerError) =>{
        setSnackbarSeverity("error");
        setSnackbarMessage(serverError.message);
        setSnackbarOpen(true);
    }
    const validationError = (validationError: CoolValidationError) =>{
        console.log(validationError);
        setSnackbarSeverity("error");
        setSnackbarMessage(validationError.errors[0].errors[0]);
        setSnackbarOpen(true);
    }

    return(
        <AlertReactContext.Provider value={{ success, error, serverError, validationError }}>
            {props.children}
            <Snackbar
              open={snackbarOpen}
              onClose={handleClose}
              autoHideDuration={6000}
              anchorOrigin={{ vertical: "top", horizontal: "center" }}
            >
              <Alert
                variant="filled"
                onClose={handleClose}
                severity={snackbarSeverity}
              >
                {snackbarMessage}
              </Alert>
            </Snackbar>
        </AlertReactContext.Provider>
    );
}