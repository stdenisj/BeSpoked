import { Button, Card, CardActions, CardContent, CardMedia, Grid, Typography } from "@mui/material";
import { SalesPerson } from "../../../Entities/SalesPerson";
import { GridGrow } from "../../../Components/GridGrow";
import { useState } from "react";
import { UpdateSalesPersonDialog } from "./UpdateSalesPersonDialog";

type SalesPersonCardProps = {
    person:SalesPerson
};

export function SalesPersonCard(props:SalesPersonCardProps){
    const { person } = props

    const [showUpdateDialog, setShowUpdateDialog] = useState(false);

    return(
        <Grid item xs={12} sm={6} md={4} lg={3}>
            <Card >
                <CardMedia
                sx={{ height: 140 }}
                image="https://placekitten.com/200/287"
                />
                <CardContent>
                    <Typography gutterBottom variant="h5" component="div">
                        {`${person.firstName} ${person.lastName}`}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Phone: {person.phone}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        StartDate: {person.startDate.toLocaleDateString("en-US")}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        { person.terminationDate && `TerminationDate: ${person.terminationDate.toLocaleDateString("en-US")}`}
                    </Typography>
                </CardContent>
                <CardActions>
                    <GridGrow />
                    <Button size="small" onClick={() => setShowUpdateDialog(true)}>Update</Button>
                </CardActions>
            </Card>
            { showUpdateDialog && 
                <UpdateSalesPersonDialog 
                    open={showUpdateDialog} 
                    onClose={() => setShowUpdateDialog(false)} 
                    person={person} 
                />
            }
        </Grid>
    )
}