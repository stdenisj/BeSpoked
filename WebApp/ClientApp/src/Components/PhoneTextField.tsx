import { TextField, TextFieldProps } from "@mui/material";
import React from "react";
import { IMaskInput } from 'react-imask';


type Props = Omit<TextFieldProps, "value" | "onChange"> & {
	onChangePhoneNumber: (phoneNumber: string) => void;
	value: string;
}

interface CustomProps {
	onChange: (event: { target: { name: string; value: string } }) => void;
	name: string;
  }
  
  const TextMaskCustom = React.forwardRef<HTMLElement, CustomProps>(
	function TextMaskCustom(props, ref) {
	  const { onChange, ...other } = props;
	  return (
		<IMaskInput
		  {...other}
		  mask="(#00) 000-0000"
		  definitions={{
			'#': /[1-9]/,
		  }}
		  inputRef={ref as any}
		  onAccept={(value: any) => onChange({ target: { name: props.name, value } })}
		  overwrite
		/>
	  );
	},
  );

export function PhoneTextField(props: TextFieldProps & Props) {
	const { onChangePhoneNumber, value, ...textFieldProps } = props;

	const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		const numbers = e.target.value.replace(/\D/g, "");
		if(numbers.length === 0) {
			onChangePhoneNumber("");
		}
		else if(numbers.length <= 10) {
			onChangePhoneNumber(numbers);
		} else {
			onChangePhoneNumber(numbers.substring(0, 10));
		}
	}

	return (
		<TextField
			{...textFieldProps}
			onChange={onChange}
			value={value}
			InputProps={{
				...textFieldProps.InputProps,
				// eslint-disable-next-line @typescript-eslint/no-explicit-any
				inputComponent: TextMaskCustom as any,
			}}
		/>
	);
}
