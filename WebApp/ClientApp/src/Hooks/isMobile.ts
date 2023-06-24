/* eslint-disable react-hooks/rules-of-hooks */
import { useMediaQuery, useTheme } from "@mui/material";

export function isMobile(size?: "xs" | "sm"){
    const theme = useTheme();
	const mobileFormFactor = useMediaQuery(theme.breakpoints.down(size ?? "sm"));
    return mobileFormFactor;
}