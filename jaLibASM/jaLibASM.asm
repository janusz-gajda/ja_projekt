.code

calculateLuhnValueASM proc
	;move string to xmm7 register
	movups xmm7, [rcx]

	;remove ansiiOffsett, so we get actual values
	psubb xmm7, ansiiOffsett

	;multiply even positions
	movaps xmm2, xmmword ptr [zeroVector]
	movaps xmm0, xmmword ptr [maskVector]
	pblendvb xmm2, xmm7, xmm0
	paddb xmm7, xmm2

	;fix values above 9
	movaps xmm2, xmmword ptr [zeroVector]
	movaps xmm0, xmm7
	pcmpgtb xmm0, xmmword ptr [nineVector]
	pblendvb xmm2, xmmword ptr [nineVector], xmm0
	psubb xmm7, xmm2

	;sum values and return 10 - (x mod 10)
	psadbw xmm7, xmmword ptr [zeroVector]
	movq rax, xmm7
	movhlps xmm7, xmm7
	movq rbx, xmm7

	add rax, rbx
	mov rdx, 0
	div qword ptr [ten]
	add rdx, 0
	jz zero

	mov rax, 10
	sub rax, rdx
	ret

	zero:
	mov rax, rdx
	ret
calculateLuhnValueASM endp

.data
	ansiiOffsett db 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h, 30h
	maskVector db 0ffh, 00h, 0ffh, 00h, 0ffh, 00h, 0ffh, 00h, 0ffh, 00h, 0ffh, 00h, 0ffh, 00h, 0ffh, 00h
	zeroVector db 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h, 00h
	nineVector db 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h, 09h
	ten dq 10
end