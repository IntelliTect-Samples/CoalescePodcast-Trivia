<template>
  <v-card>
    <v-sheet color="secondary">
      <v-card-title>
        <v-icon class="mb-2 mr-2">fa-solid fa-question-circle</v-icon>
        {{ question.text }}
      </v-card-title>
    </v-sheet>
    <v-card-text>
      <AnswerChip
        v-for="answer in question.answers"
        :key="answer.$stableId"
        :answer="answer"
        :question="question"
        @click="pickAnswer(answer)"
        :color="answerColor(answer)"
      />
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { AnswerViewModel, QuestionViewModel } from "@/viewmodels.g";

const props = defineProps<{
  question: QuestionViewModel;
}>();

const selectedAnswerId = ref<string | null>(null);

function answerColor(answer: AnswerViewModel) {
  if (selectedAnswerId.value === null) {
    return "grey";
  }

  if (selectedAnswerId.value === props.question.correctAnswerId) {
    if (answer.answerId === selectedAnswerId.value) {
      return "success";
    }
  }

  if (selectedAnswerId.value === answer.answerId) {
    return "warning";
  }

  if (answer.answerId === props.question.correctAnswerId) {
    return "success";
  }

  return "error";
}

function pickAnswer(answer: AnswerViewModel) {
  console.log("Clicked");
  selectedAnswerId.value = answer.answerId;
}
</script>
